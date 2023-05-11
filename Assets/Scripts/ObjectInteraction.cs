using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private bool interactActive = false;
    public GameObject interactable;
    public GameObject canvasE;
    public GameObject canvasInstructions;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactActive = true;
            canvasE.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactActive = false;
            canvasE.SetActive(false);
            canvasInstructions.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactActive && Input.GetKeyDown(KeyCode.E))
        {
            interactable.SetActive(true);
            canvasE.SetActive(false);
            canvasInstructions.SetActive(true);
        }
    }
}
