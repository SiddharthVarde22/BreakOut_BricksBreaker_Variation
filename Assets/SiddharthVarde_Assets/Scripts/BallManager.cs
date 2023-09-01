using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    [SerializeField]
    int NumberOfBallsToSpawn = 50;

    List<BallMovements> spawnedBalls;
    [SerializeField]
    float timeIntervalToShootTheball;

    int numberOfBallsInHold = 50;
    PlayerManager playerManager;

    private void Start()
    {
        spawnedBalls = new List<BallMovements>();
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ShootTheBall());
        }
    }

    IEnumerator ShootTheBall()
    {
        //GetComponent<PlayerMovements>().enabled = false;
        playerManager.DisablePlayer();
        int i = NumberOfBallsToSpawn - spawnedBalls.Count;
        int x = i;

        if (spawnedBalls.Count < NumberOfBallsToSpawn)
        {
            while(i > 0)
            {
                BallMovements ball = Instantiate(ballPrefab, transform.position, Quaternion.identity).GetComponent<BallMovements>();
                spawnedBalls.Add(ball);
                ball.BounceInDirection(transform.up);
                numberOfBallsInHold--;
                yield return new WaitForSeconds(timeIntervalToShootTheball);
                i--;
            }
        }

        for(int j = x; j < NumberOfBallsToSpawn; j++)
        {
            spawnedBalls[j].gameObject.SetActive(true);
            spawnedBalls[j].transform.position = transform.position;
            spawnedBalls[j].BounceInDirection(transform.up);
            numberOfBallsInHold--;
            yield return new WaitForSeconds(timeIntervalToShootTheball);
        }
        //GetComponent<PlayerMovements>().enabled = true;
    }

    public void BallRecievedBack()
    {
        numberOfBallsInHold++;
        if(numberOfBallsInHold >= NumberOfBallsToSpawn)
        {
            playerManager.EnablePlayer();
        }
    }
}
