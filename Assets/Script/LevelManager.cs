using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject nextLevelButton; // Referensi tombol next level
    public int totalEnemies = 10;

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length; // Hitung jumlah musuh
        nextLevelButton.SetActive(false); // Sembunyikan tombol di awal
    }

    public void EnemyDefeated()
    {
        totalEnemies--; // Kurangi jumlah musuh

        if (totalEnemies <= 0)
        {
            nextLevelButton.SetActive(true); // Tampilkan tombol jika semua musuh dikalahkan
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Pindah ke scene berikutnya
    }
}
