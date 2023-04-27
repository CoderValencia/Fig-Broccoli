using UnityEngine;
using UnityEngine.SceneManagement;

public class DropOff : MonoBehaviour
{
    public bool dropOffArea;

    public int pickUpCount;

    private void Update()
    {
        if (pickUpCount == 5)
        {
            SceneManager.LoadScene("TysonScene2");
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
