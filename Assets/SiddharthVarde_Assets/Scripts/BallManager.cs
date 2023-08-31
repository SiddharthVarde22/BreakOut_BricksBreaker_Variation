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

    private void Start()
    {
        spawnedBalls = new List<BallMovements>();
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
        GetComponent<PlayerMovements>().enabled = false;
        int i = NumberOfBallsToSpawn - spawnedBalls.Count;
        int x = i;

        if (spawnedBalls.Count < NumberOfBallsToSpawn)
        {
            while(i > 0)
            {
                BallMovements ball = Instantiate(ballPrefab, transform.position, Quaternion.identity).GetComponent<BallMovements>();
                spawnedBalls.Add(ball);
                ball.BounceInDirection(transform.up);
                yield return new WaitForSeconds(timeIntervalToShootTheball);
                i--;
            }
        }

        for(int j = x; j < NumberOfBallsToSpawn; j++)
        {
            spawnedBalls[j].BounceInDirection(transform.up);
            yield return new WaitForSeconds(timeIntervalToShootTheball);
        }
        GetComponent<PlayerMovements>().enabled = true;
    }
}
