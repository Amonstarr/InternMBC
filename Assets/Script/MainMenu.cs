using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Fungsi untuk tombol Play Game
    public void PlayGame()
    {
        SceneManager.LoadScene("CutScene1");
    }

    // Fungsi untuk tombol Options
    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    // Fungsi untuk tombol Keluar
    public void QuitGame()
    {
        Debug.Log("Keluar dari game.");
        Application.Quit(); 
    }
}
