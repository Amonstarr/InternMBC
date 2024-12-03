using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; 
    public PlayerHealth playerHealth; 
    private static GameOverManager instance; 


    private void Start()
    {
        gameOverCanvas.SetActive(false); 
    }

    public void ActivateGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); 
            Time.timeScale = 0f; 
        }
        else
        {
            Debug.LogError("GameOver Canvas reference is missing!");
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1f; 
        playerHealth.ResetHealthAndPosition(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }


    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu"); 
    }
}
