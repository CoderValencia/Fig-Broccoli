using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Rigidbody rb;
    public Collider coll;
    public Transform player, itemContainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;

    private void Start()
    {
        if(!equipped)
        {
            rb.isKinematic= false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;

        }
    }
    private void PickUpFunction()
    {
        equipped = true;

        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one; 

        rb.isKinematic = true;
        coll.isTrigger = true;

    }

    private void DropFunction()
    {

        equipped = true;

        transform.SetParent(null);

        rb.velocity = player.GetComponent<Rigidbody>().velocity;    

        rb.isKinematic = true;
        coll.isTrigger = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player is inside  pick up space");
          

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player left pick up space");
           

        }

    }
}
