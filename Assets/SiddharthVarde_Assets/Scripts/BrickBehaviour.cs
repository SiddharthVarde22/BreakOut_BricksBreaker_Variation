using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    int numberOfCollisionsNedded = 30;

    [SerializeField]
    TextMesh numberOfCollisionsText;

    // Start is called before the first frame update
    void Start()
    {
        //register as a brick in game manager
        EditNumberOfCollisionsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallMovements ballMovements = null;

        if(collision.transform.TryGetComponent<BallMovements>(out ballMovements))
        {
            OnClollidedWithBall();
        }
    }

    void OnClollidedWithBall()
    {
        numberOfCollisionsNedded--;
        EditNumberOfCollisionsText();
        if (numberOfCollisionsNedded <= 0)
        {
            DestroyBrick();
        }
    }

    public void DestroyBrick()
    {
        //reduce number of remaining bricks from game manager
        Destroy(gameObject);
    }

    void EditNumberOfCollisionsText()
    {
        numberOfCollisionsText.text = numberOfCollisionsNedded.ToString();
    }
}
