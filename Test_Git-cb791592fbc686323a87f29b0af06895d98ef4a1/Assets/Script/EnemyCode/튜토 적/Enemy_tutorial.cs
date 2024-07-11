using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_tutorial : MonoBehaviour
{
    public float Hp = 5f;
    public void Damage(float AttakeDamge)
    {
        Hp -= AttakeDamge;
        if (Hp <= 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        Destroy(gameObject,3);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
