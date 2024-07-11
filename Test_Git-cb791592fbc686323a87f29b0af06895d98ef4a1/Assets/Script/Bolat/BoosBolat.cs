using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BoosBolat : MonoBehaviour
{
    private float Speed = 10f;
    int count;
    private void Update()
    {
        if(count == 0)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            StartCoroutine(TunBolat());
        }
        if(count == 1)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            Destroy(gameObject,10);
        }
    }
    IEnumerator TunBolat()
    {
        yield return new WaitForSeconds(3);
        count = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStactGm.PGm.Hp -= TutoralBoosStactGm.TbGm.Damaged;
            Destroy(gameObject);
        }
    }
}
