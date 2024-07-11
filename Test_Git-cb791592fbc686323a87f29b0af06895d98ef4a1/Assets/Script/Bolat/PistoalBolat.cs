using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PistoalBolat : MonoBehaviour
{
    public LayerMask TarGet;
    float Speed = 15;
    private void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("fd");
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "tutorialEnemy")
        {
            collision.gameObject.GetComponent<Enemy_tutorial>().Damage(PlayerStactGm.PGm.Damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Generator")
        {
            collision.gameObject.GetComponent<GenertorCode>().Damage(PlayerStactGm.PGm.Damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BoosTutoral")
        {
            TutoralBoosStactGm.TbGm.Damage(PlayerStactGm.PGm.Damage);
            Destroy(gameObject);
        }
        /*
        int Layer = TarGet;
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, Layer);
        if (Hit.collider != null)
        {
            switch (Hit.collider.gameObject.tag)
            {
                case "Ground":
                    Destroy(gameObject);
                    break;
                case "tutorialEnemy":
                    Destroy(gameObject);
                    Hit.collider.GetComponent<Enemy_tutorial>().Damage(PlayerStactGm.PGm.Hp);
                    break;
                case "Generator":
                    Destroy(gameObject);
                    Hit.collider.GetComponent<GenertorCode>().Damage(PlayerStactGm.PGm.Hp);
                    break;
            }
        }
        */
        /*
        if(collision.gameObject.tag == "tutorialEnemy")
        {
            Collider2D[] HitEnemy_tutoroal = Physics2D.OverlapCircleAll(transform.position,1f, TarGet);
            foreach (Collider2D enemy in HitEnemy_tutoroal)
            {
                enemy.GetComponent<Enemy_tutorial>().Damage(PlayerStactGm.PGm.Damage);
            }
            Destroy(this.gameObject);
        }*/

    }
}
