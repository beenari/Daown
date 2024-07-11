using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistoalBolat_Enemy : MonoBehaviour
{
    float Speed = 15;

    public float Damage;

    public WEAPONDamage WD = WEAPONDamage.pistol;
    public enum WEAPONDamage
    {
        pistol,
        rockat,
        musing_gun

    }
    private void Update()
    {
        CkWeapone();
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStactGm.PGm.Hp -= Damage;
            Destroy(gameObject);
        }
    }
    void CkWeapone()
    {
        if (WD == WEAPONDamage.pistol)
            Damage = 2f;
        else if (WD == WEAPONDamage.rockat)
            Damage = 5f;
        else if (WD == WEAPONDamage.musing_gun) Damage = 1f;
    }

}

