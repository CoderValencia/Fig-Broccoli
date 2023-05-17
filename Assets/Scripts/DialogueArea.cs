using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Linq;
using System.Collections.Generic;

public class DialogueArea : MonoBehaviour
{
    public bool areaVisible;
    public TextAsset inkJson;
    private Story currentStory;
    public bool dialogueIsPlaying;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI dialoguePrompt;
    public GameObject dialogueBox;


 
    public TextMeshProUGUI speakerName;
    public Animator portraitAnim;


    Scene currentScene;

    const string SPEAKER_TAG = "speaker";

    private void Start()
    {
        areaVisible = true;
        currentScene = SceneManager.GetActiveScene();
        dialoguePrompt.gameObject.SetActive(false);
        dialogueBox.SetActive(false);
        dialogueIsPlaying = false;
   
         

    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E) && dialoguePrompt.gameObject.activeInHierarchy == true )
        {
            EnterDialogueMode(inkJson);
           
        }
        if (dialogueBox == true && Input.GetMouseButtonDown(0))
        {
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

       
        dialoguePrompt.gameObject.SetActive(false);
       



    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueBox.SetActive(true);
        dialogueIsPlaying = true;


        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            HandleTags(currentStory.currentTags);
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

        switch (currentScene.name)
        {
            case "Level_1_beta_layout_Tyson":
                SceneManager.LoadScene("Level_1_beta_layout");
                break;
            default:
                break;

        }
        
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogue();
            
        }
    }

    void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.Log(splitTag.Length);
                Debug.LogError("Tag could not be parsed:" + tag);
            }
            string tagKey = splitTag[0];
            string tagValue = splitTag[1];
            speakerName.text = tagValue;
            Debug.Log(tagValue);
            switch (tagValue)
            {
                case "Broccoli":
                    portraitAnim.Play("Broccoli");
                    break;
                case "Fig":
                    portraitAnim.Play("Fig");
                    break;
                case "Tyson":
                    portraitAnim.Play("Tyson");
                    break;
                default:
                    break;

            }

        }

    }

}
