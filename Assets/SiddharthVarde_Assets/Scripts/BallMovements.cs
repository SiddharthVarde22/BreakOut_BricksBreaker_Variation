using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovements : MonoBehaviour
{
    [SerializeField]
    float forceToAdd = 10;
    [SerializeField]
    float ballMovementSpeed = 10;

    Rigidbody2D rigidbody;

    bool isMovingTowardsPlayer;
    static BallManager ballManagerRefrence = null;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMovingTowardsPlayer)
        {
            Vector3 target = GameManager.Instance.Player.position;
            transform.position += (target - transform.position).normalized * ballMovementSpeed * Time.deltaTime;

            if((transform.position - target).magnitude < 0.1f)
            {
                if(ballManagerRefrence == null)
                {
                    ballManagerRefrence = GameManager.Instance.Player.GetComponent<BallManager>();
                }
                ballManagerRefrence.BallRecievedBack();
                gameObject.SetActive(false);
            }
        }
    }

    public void BounceInDirection(Vector2 direction)
    {
        rigidbody.velocity = direction * forceToAdd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 currentDirection = rigidbody.velocity.normalized;
        float directionChange = 0;
        if (currentDirection.y <= 0.1f && currentDirection.y >= -0.1f)
        {
            if (currentDirection.y >= 0)
            {
                directionChange = 0.1f;
            }
            else
            {
                directionChange = -0.1f;
            }
        }

        float xDirectionChange = 0;

        if (currentDirection.x <= 0.1f && currentDirection.x >= -0.1f)
        {
            if (currentDirection.x >= 0)
            {
                xDirectionChange = 0.1f;
            }
            else
            {
                xDirectionChange = -0.1f;
            }
        }

        BounceInDirection(new Vector2(currentDirection.x + xDirectionChange, currentDirection.y + directionChange));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BoundryBehaviour bottomTrigger = null;

        if(collision.TryGetComponent<BoundryBehaviour>(out bottomTrigger))
        {
            rigidbody.velocity = Vector2.zero;
            isMovingTowardsPlayer = true;
        }
    }

    private void OnDisable()
    {
        isMovingTowardsPlayer = false;
    }
}
