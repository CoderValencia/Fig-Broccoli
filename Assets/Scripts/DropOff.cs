using JetBrains.Annotations;
using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    public bool dropOffArea;

    public int pickUpCount;

    private void Update()
    {
        if (pickUpCount == 5)
        {
            Debug.Log(" Everything collected");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
       

        if (collision.tag == "Player")
        {
            Debug.Log("Player is inside drop off space");
            dropOffArea = true;


        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player left drop off space");
            dropOffArea = false;


        }

    }
}
