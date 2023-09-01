using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    int numberOfBricksInLevel = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform Player
    {
        get;
        set;
    }

    public void IncreaseNumberOfBricksInLevel()
    {
        numberOfBricksInLevel++;
    }

    public void DecreaseNumberOfBricksInLevel()
    {
        numberOfBricksInLevel--;
        if(numberOfBricksInLevel <= 0)
        {
            numberOfBricksInLevel = 0;
            //load next level
            GetComponent<LevelLoader>().LoadNextScene();
        }
    }
}
