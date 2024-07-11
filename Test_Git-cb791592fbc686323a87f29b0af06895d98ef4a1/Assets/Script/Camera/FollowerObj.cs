using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerObj : MonoBehaviour
{
    public Transform Player;
    public float Range = 1.5f;

    private void Update()
    {
        if (!CameraChangeGm.CmGm.booszone)
        {
            transform.position = Vector3.Lerp(transform.position, Player.position, 2);
            if (PlayerStactGm.PGm.TurnRight == 1)
                transform.position = new Vector3(transform.position.x + Range, transform.position.y, -10f);
            else if (PlayerStactGm.PGm.TurnRight == -1)
                transform.position = new Vector3(transform.position.x - Range, transform.position.y, -10f);
        }
    }
}
