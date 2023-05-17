using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimbStairs : MonoBehaviour
{
    public GameObject player;
    private bool interactClimb;
    public GameObject canvasClimb;
    public Vector3 v3Upstairs;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactClimb = true;
            canvasClimb.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactClimb = false;
            canvasClimb.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactClimb && Input.GetKeyDown(KeyCode.E))
        {
            canvasClimb.SetActive(false);
            player.transform.position = v3Upstairs;
        }
    }
}