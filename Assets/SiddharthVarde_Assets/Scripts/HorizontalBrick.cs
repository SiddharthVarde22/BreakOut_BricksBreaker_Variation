using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBrick : BrickBehaviour
{
    [SerializeField]
    BoxCollider2D triggerHorizontal;

    protected override void Start()
    {
        base.Start();
    }

    public override void DestroyBrick()
    {
        //Debug.Log("Trigger active");
        triggerHorizontal.isTrigger = true;
        triggerHorizontal.size = new Vector2(25, 0.5f);
        //base.DestroyBrick();
        GameManager.Instance.DecreaseNumberOfBricksInLevel();
        //Debug.Log(gameObject.name);
        Destroy(gameObject, 0.2f);
    }
}
