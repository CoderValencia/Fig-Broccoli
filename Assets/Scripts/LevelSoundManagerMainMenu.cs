using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSoundManagerMainMenu: MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
      

        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "StartMenu")
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
