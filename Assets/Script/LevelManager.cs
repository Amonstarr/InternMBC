using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject nextLevelButton;
    public int totalEnemies = 10;

    private void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        nextLevelButton.SetActive(false);
    }

    private void Update(){
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemyDefeated()
    {
        totalEnemies--; 

        if (totalEnemies <= 0)
        {
            nextLevelButton.SetActive(true); 
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
