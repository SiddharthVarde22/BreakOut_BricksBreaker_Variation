using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBallPath : MonoBehaviour
{
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    LayerMask layersToCollide;

    RaycastHit2D raycastHit2D;

    // Update is called once per frame
    void Update()
    {
        DrawThePath();
    }

    Vector3 startPosition, startDirection;
    void DrawThePath()
    {
        startPosition = transform.position;
        startDirection = transform.up;
        //Debug.Log(startDirection + " , " + transform.localEulerAngles);
        raycastHit2D = Physics2D.Raycast(transform.position, startDirection, layersToCollide);

        if(raycastHit2D)
        {
            Vector2 lastPosition = raycastHit2D.point + Vector2.Reflect(startDirection, raycastHit2D.normal) * 3;
            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, raycastHit2D.point);
            lineRenderer.SetPosition(2, lastPosition);
            lineRenderer.gameObject.SetActive(true);
        }
        else
        {
            lineRenderer.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (lineRenderer != null)
        {
            lineRenderer.gameObject.SetActive(false);
        }
    }
}
