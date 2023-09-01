using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    protected int numberOfCollisionsNedded = 30;

    [SerializeField]
    TextMesh numberOfCollisionsText;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //register as a brick in game manager
        GameManager.Instance.IncreaseNumberOfBricksInLevel();
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

    virtual public void DestroyBrick()
    {
        //reduce number of remaining bricks from game manager
        GameManager.Instance.DecreaseNumberOfBricksInLevel();
        //Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

    void EditNumberOfCollisionsText()
    {
        numberOfCollisionsText.text = numberOfCollisionsNedded.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HorizontalBrick horizontalBrick = null;
        BlasterBrick blasterBrick = null;

        if(collision.TryGetComponent<HorizontalBrick>(out horizontalBrick))
        {
            DestroyBrick();
        }
        else if(collision.TryGetComponent<BlasterBrick>(out blasterBrick))
        {
            DestroyBrick();
        }
    }
}
