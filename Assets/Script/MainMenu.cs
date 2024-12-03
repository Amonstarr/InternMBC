using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("CutScene1");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }
    
    public void QuitGame()
    {
        Debug.Log("Keluar dari game.");
        Application.Quit(); 
    }
}
