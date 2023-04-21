using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Rendering;
using UnityEngine;

public class DialogueArea : MonoBehaviour
{
    public bool areaVisible;

    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;

    private int index;

     void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == lines[index])
            {
                NextLine();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is inside talking space");
            areaVisible = true;
            dialogueText.text = string.Empty;
            StartDialogue();

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("Player left talking space");
            areaVisible = false;

        }

    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {

        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }


    }

    void NextLine()
    {
        if (index < lines.Length -1) 
        {
            index++;
            dialogueText.text = String.Empty;
            StartCoroutine(TypeDialogue());
        
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
