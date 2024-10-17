using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;  // Panel pause menu
    private bool isPaused = false;     // Status pause

    // Fungsi untuk memanggil pause
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
        pauseMenuPanel.SetActive(false);  // Nonaktifkan pause menu
        Time.timeScale = 1f;              // Jalankan waktu kembali
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);  // Aktifkan pause menu
        Time.timeScale = 0f;             // Hentikan waktu
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game!");
        SceneManager.LoadScene("Main Menu");  // Ganti ke scene MainMenu
    }
}
