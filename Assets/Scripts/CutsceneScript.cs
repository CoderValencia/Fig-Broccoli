using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    public bool areaVisible;
    public TextAsset inkJson;
    private Story currentStory;
    public bool dialogueIsPlaying;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerName;
    public Animator portraitAnim;

    public GameObject dialogueBox;

    Scene currentScene;

    const string SPEAKER_TAG = "speaker";


    private void Start()
    {
        areaVisible = true;
        dialogueBox.SetActive(false);
        dialogueIsPlaying = false;
        currentScene = SceneManager.GetActiveScene();
        EnterDialogueMode(inkJson);


    }

    void Update()
    {
      
       
        if (dialogueBox == true && Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
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
            case "Opening":
                SceneManager.LoadScene("TysonGameplay");
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
            switch (tagValue)
            {
                case "Broccoli":
                    portraitAnim.Play("Broccoli");
                    break;
                case "Fig":
                    portraitAnim.Play("Fig");
                    break;
                default: 
                    break;

            }

        }
        
    }

}
