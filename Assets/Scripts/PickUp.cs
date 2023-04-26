using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   // public Rigidbody rb;
    public Collider coll;
    public Transform player, itemContainer, dropContainer;

    public DropOff dropOff;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;

    public bool inArea;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.X) && inArea == true && equipped == false)
        {
            
            PickUpFunction();
    
        }
        else if (Input.GetKey(KeyCode.Z) && dropOff.dropOffArea == true && equipped == true)
        {

            DropOffFunction();
        }
        
    }
    private void PickUpFunction()
    {


        transform.SetParent(itemContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        equipped = true;
        coll.isTrigger = true;

    }

    private void DropOffFunction()
    {
  

        transform.SetParent(dropContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        equipped = false;
        coll.isTrigger = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            inArea = true;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            inArea = false;


        }
    }

}
