using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class DialogueArea : MonoBehaviour
{
    public bool areaVisible;

    public TextAsset inkJson;

    private Story currentStory;
    public bool dialogueIsPlaying;




    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialoguePrompt;
    public GameObject dialogueBox;

   

    private void Start()
    {
        areaVisible = true;
        dialoguePrompt.gameObject.SetActive(false);
        dialogueBox.SetActive(false);
       dialogueIsPlaying = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnterDialogueMode(inkJson);
           
        }
        if (dialogueBox == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");
            ContinueStory();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is in talking space");
            
            dialoguePrompt.gameObject.SetActive(true);
           


        }
    }
    private void OnTriggerExit(Collider collision)
    {

        Debug.Log("Player left talking space");
        dialoguePrompt.gameObject.SetActive(false);
       



    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueBox.SetActive(true);
        dialogueIsPlaying = true;
        Debug.Log("Dialgoue Box opened");

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogue();
        }
    }
    void ExitDialogue()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false) ;
        dialogueText.text = "";
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogue();
        }
    }

}
