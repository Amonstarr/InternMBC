using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);  
        Time.timeScale = 1f;              
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);  
        Time.timeScale = 0f;             
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game!");
        SceneManager.LoadScene("Main Menu");  
    }
}
