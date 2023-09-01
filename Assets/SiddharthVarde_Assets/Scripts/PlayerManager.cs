using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public void DisablePlayer()
    {
        GetComponent<PlayerMovements>().enabled = false;
        GetComponent<DrawBallPath>().enabled = false;
    }

    public void EnablePlayer()
    {
        GetComponent<PlayerMovements>().enabled = true;
        GetComponent<DrawBallPath>().enabled = true;
    }
}
