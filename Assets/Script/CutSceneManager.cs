using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("cs1"); // Pindah ke scene berikutnya
    }
}
