using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    int sceneToLoad = 0;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
