using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextScene : MonoBehaviour
{
    public void LoadNextScen(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }
}


