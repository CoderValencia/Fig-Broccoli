using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private bool interactActive = false;
    private bool hasInteracted = false;
    public bool nothingHere = false;

    // Quest object to reveal
    public GameObject questObject;

    // Canvas that says "Press E to Interact"
    public GameObject canvasE; 

    // Canvas that shows result of interaction
    public GameObject canvasResult;

    // Canvas that tells player there's nothing else here
    public GameObject canvasHasInteracted;


    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasInteracted == false)
        {
            interactActive = true;
            canvasE.SetActive(true);
            canvasHasInteracted.SetActive(false);
        }

        if (other.CompareTag("Player") && hasInteracted == true)
        {
            interactActive = true;
            nothingHere = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactActive = false;
            canvasE.SetActive(false);
            canvasResult.SetActive(false);
            canvasHasInteracted.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactActive && nothingHere == false && Input.GetKeyDown(KeyCode.E))
        {
            questObject.SetActive(true);
            canvasE.SetActive(false);
            canvasResult.SetActive(true);
            hasInteracted = true;
        }

        if (interactActive && nothingHere == true && Input.GetKeyDown(KeyCode.E))
        {
            canvasHasInteracted.SetActive(true);
        }

    }
}
