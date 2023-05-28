using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeysScript : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public int totalKeys;
    public PickUp pianoPickUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = totalKeys.ToString();
        if (pianoPickUp.PianoDroppedOff == true && totalKeys == 4)
        {
            SceneManager.LoadScene("Level1_TysonDone");
        }
    }
}
