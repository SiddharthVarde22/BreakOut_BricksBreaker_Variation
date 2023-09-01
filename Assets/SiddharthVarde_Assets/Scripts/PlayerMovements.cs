using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 10, rotationSpeed = 10;

    float horizontalInput;
    float verticalInput;

    float leftX, rightX;

    float rotaion = 0;
    [SerializeField]
    float rotationLimitLeft = 80, rotationLimitRight = -80;

    // Start is called before the first frame update
    void Start()
    {
        leftX = BounryCalculator.Instance.GetLeftX() + 0.5f;
        rightX = BounryCalculator.Instance.GetRightX() - 0.5f;
        GameManager.Instance.Player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Movement();
        Rotate();
    }

    void Movement()
    {
        transform.position += Vector3.right * playerSpeed * horizontalInput * Time.deltaTime;

        if(transform.position.x >= rightX)
        {
            transform.position = new Vector3(rightX, transform.position.y, 0);
        }

        if(transform.position.x <= leftX)
        {
            transform.position = new Vector3(leftX, transform.position.y, 0);
        }
    }

    void Rotate()
    {
        rotaion += verticalInput * rotationSpeed * Time.deltaTime;

        rotaion = Mathf.Clamp(rotaion, rotationLimitRight, rotationLimitLeft);

        transform.rotation = Quaternion.Euler(0, 0, rotaion);
    }
}
