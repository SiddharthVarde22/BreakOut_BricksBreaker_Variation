using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounryCalculator : MonoBehaviour
{
    public static BounryCalculator Instance { get; private set; }

    float leftX, rightX, upY, lowerY;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            CalculateBoundries();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(" -x " + leftX + " +x " + rightX + " +y " + upY + " -y " + lowerY);
    }

    void CalculateBoundries()
    {
        Camera mainCamera = Camera.main;
        rightX = mainCamera.ViewportToWorldPoint(Vector3.right).x;
        leftX = -1 * rightX;
        upY = mainCamera.ViewportToWorldPoint(Vector3.up).y;
        lowerY = -1 * upY;
    }

    public float GetLeftX()
    {
        return leftX;
    }

    public float GetRightX()
    {
        return rightX;
    }

    public float GetUpY()
    {
        return upY;
    }

    public float GetLowerY()
    {
        return lowerY;
    }
}
