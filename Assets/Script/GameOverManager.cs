using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Referensi ke Game Over UI
    public PlayerHealth playerHealth; // Referensi ke komponen PlayerHealth
    private static GameOverManager instance; // Singleton instance


    private void Start()
    {
        gameOverCanvas.SetActive(false); // Pastikan UI game over tidak aktif di awal
    }

    public void ActivateGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true); // Aktifkan Game Over UI
            Time.timeScale = 0f; // Hentikan waktu
        }
        else
        {
            Debug.LogError("GameOver Canvas reference is missing!");
        }
    }


    public void RestartGame()
    {
        Time.timeScale = 1f; // Jalankan kembali waktu
        playerHealth.ResetHealthAndPosition(); // Reset health dan posisi player
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart level saat ini
    }


    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Jalankan waktu normal
        SceneManager.LoadScene("Main Menu"); // Pindah ke Main Menu
    }
}
