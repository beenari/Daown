using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BigGunCode : MonoBehaviour
{
    [SerializeField]
    private Transform TarGet;
    public Transform ShsPotionObj;
    Vector3 ShsPotion;
    public GameObject Amount;

    Vector2 Pos;
    Vector2 adi;

    public float Hp = 150;

    public float CollTime = 3;
    private void Update()
    {
        ShsPotion = ShsPotionObj.transform.position;
        TarGetCk();
        Shs();
        Dead();
    }
    void TarGetCk()
    {
        Pos = new Vector3(TarGet.transform.position.x, TarGet.transform.position.y);
        adi = (Pos - (Vector2)transform.position).normalized;

        transform.right = adi;
    }
    void Shs()
    {
        if(CollTime < 0)
        {
            StartCoroutine(Shsing());
            CollTime = 3;
        }
        else if (CollTime > 0)
        {
            CollTime -= Time.deltaTime;        
        }
    }
    IEnumerator Shsing()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(Amount, ShsPotion, transform.rotation);
        }
    }
    void Dead()
    {
        if(Hp <= 0)
        {
            Debug.Log("Dad");
            Destroy(gameObject, 3);
            this.enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Amount")
            Hp -= PlayerStactGm.PGm.Damage;
    }
}
