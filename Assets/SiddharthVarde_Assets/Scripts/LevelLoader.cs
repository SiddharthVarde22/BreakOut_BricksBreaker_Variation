using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        if(sceneToLoad >= SceneManager.sceneCountInBuildSettings)
        {
            sceneToLoad = 0;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
