using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public GameObject DialoguePanel;
    public DialogueArea dialogueArea;

   

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueArea.areaVisible == false)
        {
            DialoguePanel.SetActive(false);
        }
        
        if (dialogueArea.areaVisible == true) 
        { 
            DialoguePanel.SetActive(true);
           

        }
        
    }

    
}