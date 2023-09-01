using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBrick : BrickBehaviour
{
    [SerializeField]
    BoxCollider2D boxCollider;
    [SerializeField]
    CircleCollider2D circleCollider;

    public override void DestroyBrick()
    {
        boxCollider.enabled = false;
        circleCollider.enabled = true;
        circleCollider.radius = 1.5f;
        GameManager.Instance.DecreaseNumberOfBricksInLevel();
        Destroy(gameObject, 0.2f);
    }
}
