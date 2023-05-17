using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Opening_Beta");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
