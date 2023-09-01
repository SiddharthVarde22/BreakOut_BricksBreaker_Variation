using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLevelLoader : MonoBehaviour
{
    [SerializeField]
    int sceneToLoad = 0;
    [SerializeField]
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClickedLoadScene);
    }

    public void OnButtonClickedLoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
