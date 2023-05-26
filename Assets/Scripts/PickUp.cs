using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
   // public Rigidbody rb;
    public Collider coll;
    public Transform player, itemContainer, dropContainer;

    public DropOff dropOff;

    

    public bool equipped;

    public bool inArea;

    public bool dropOffComplete;

    public int dropOffItemsCount;
    public int keyCount;

    public KeysScript keysScript;

    public bool PianoDroppedOff;


    private void Start()
    {
        dropOffComplete = false;
        dropOffItemsCount = 0;
        dropOff.pickUpCount = 0;
        PianoDroppedOff = false;


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

        if (SceneManager.GetActiveScene().name == "Level0-2_Tutorial" && dropOffItemsCount == 1)
        {
            SceneManager.LoadScene("Level0-2_PreCapture");
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
        if (this.gameObject.tag == "Keys")
        {
            keysScript.totalKeys++;

        }


    }

    private void DropOffFunction()
    {
        if (this.gameObject.tag != "Keys")
        {
            transform.SetParent(dropContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            equipped = false;
            coll.isTrigger = true;
            dropOffItemsCount++;
            PianoDroppedOff = true;
        }


   
       

    }

    private void OnCollisionStay(Collision collision)
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
