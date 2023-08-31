using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovements : MonoBehaviour
{
    [SerializeField]
    float forceToAdd = 10;

    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        BounceInDirection(transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BounceInDirection(Vector2 direction)
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
}
