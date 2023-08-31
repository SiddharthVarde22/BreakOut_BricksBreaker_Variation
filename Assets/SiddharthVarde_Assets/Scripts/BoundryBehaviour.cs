using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BoundryPlace
{
    Left,
    Right,
    Up,
    Down
}

public class BoundryBehaviour : MonoBehaviour
{
    [SerializeField]
    BoundryPlace currentBoundryPlace;

    void Start()
    {
        SetPosition();
        SetSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPosition()
    {
        switch(currentBoundryPlace)
        {
            case BoundryPlace.Left:
                transform.position = Vector3.zero + transform.right * BounryCalculator.Instance.GetLeftX();
                break;
            case BoundryPlace.Right:
                transform.position = Vector3.zero + transform.right * BounryCalculator.Instance.GetRightX();
                break;
            case BoundryPlace.Up:
                transform.position = Vector3.zero + transform.up * BounryCalculator.Instance.GetUpY();
                break;
            case BoundryPlace.Down:
                transform.position = Vector3.zero + transform.up * BounryCalculator.Instance.GetLowerY();
                break;
        }
    }

    void SetSize()
    {
        transform.localScale = Vector3.one * 0.2f;
        switch(currentBoundryPlace)
        {
            case BoundryPlace.Left:
                //float height = BounryCalculator.Instance.GetUpY() * 2;
                //transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
                //break;
            case BoundryPlace.Right:
                float height = BounryCalculator.Instance.GetUpY() * 2;
                transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
                break;
            case BoundryPlace.Up:
                //float width = BounryCalculator.Instance.GetRightX() * 2;
                //transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);
                //break;
            case BoundryPlace.Down:
                float width = BounryCalculator.Instance.GetRightX() * 2;
                transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);
                break;
        }
    }
}
