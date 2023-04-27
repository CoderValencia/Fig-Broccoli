using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool dropOffComplete;

    public int dropOffItemsCount;

  

    private void Start()
    {
        dropOffComplete = false;
        dropOffItemsCount = 0;
        dropOff.pickUpCount = 0;
       
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.X) && inArea == true  && dropOffComplete == false)
        {
            
            PickUpFunction();
            if (SceneManager.GetActiveScene().name == "TysonGameplayAfterPiano")
            {
                dropOff.pickUpCount++;
                this.gameObject.SetActive(false);
            }



    
        }
        else if (Input.GetKey(KeyCode.Z) && dropOff.dropOffArea == true)
        {

            DropOffFunction();
            
            
        }

        if (SceneManager.GetActiveScene().name == "TysonGameplay" && dropOffItemsCount == 1)
        {
            SceneManager.LoadScene("TysonGameplayAfterPiano");
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
        dropOffComplete = true;
    }

    private void DropOffFunction()
    {
  

        transform.SetParent(dropContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;
        equipped = false;
        coll.isTrigger = true;
        dropOffItemsCount++;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("Pickable");
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
