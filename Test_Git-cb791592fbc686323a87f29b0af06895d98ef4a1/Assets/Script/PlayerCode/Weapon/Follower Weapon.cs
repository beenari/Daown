using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;

public class FollowerWeapon : MonoBehaviour
{
    [SerializeField]private GameObject Gun;
    Vector2 Pos;
    Vector2 direction;
    private float angel;
    void FixedUpdate()
    {
        Pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        direction = (Pos - (Vector2)Gun.transform.position).normalized;
        Gun.transform.right = direction;

        angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(1f,1f,1f);
        if (angel > 90 || angel < -90)
        {
            localScale.y = -1f;
        }
        else localScale.y = 1f;

        Gun.transform.localScale = localScale;
    }
}
