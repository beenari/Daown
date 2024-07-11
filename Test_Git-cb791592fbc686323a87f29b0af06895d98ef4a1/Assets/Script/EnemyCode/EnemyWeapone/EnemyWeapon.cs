using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{   
    [SerializeField]private GameObject Gun;
    [Header("�Ѿ� ������")][SerializeField] private GameObject Bolat;
   
    [Header("�÷��̾� ��ġ�� ���� �뵵")][SerializeField]private Transform TarGet;
    Vector2 Pos;            //�÷��̾��� ��ġ�� �޾Ƽ� ������ ����.
    Vector2 direction;      //Pos����,���� ��ġ�� �Ÿ����� ���ϴ� ����.(����ȭ)

    private float angel;
    [Header("�Ѿ� �߻� �ӵ�")]
    [SerializeField]private float Shooting_Cooltime =2f;
    [Header("���� ����")]
    public float ranges =5f;
    [Header("����")]
    public Weapon weapon = Weapon.Pistol;
    public enum Weapon
    {
        Pistol,
        Rocket,
        Musicn_Gun
    }

    private void FixedUpdate()
    {
        Shooting_Cooltime -= Time.deltaTime;
        Check_your_arget();
        ȸ��ȸ����();

        //Range range = new Range();
    }

    void TarGetCk() //�÷��̾��� ��ġ�� ���� �� �ѱ��� �÷��̾ ���ϵ���  rotation.z ���� ����.
    {
        Pos = new Vector3(TarGet.transform.position.x, TarGet.transform.position.y);
        direction = (Pos - (Vector2)Gun.transform.position).normalized;

        Gun.transform.right = direction;
    }
    void ȸ��ȸ����()
    {
        angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angel > 90 || angel < -90)
        {
            localScale.y = -1f;
        }
        else localScale.y = 1f;

        Gun.transform.localScale = localScale;
    }

    //ENEMy�߰��ؾ��Ϸ� ����.
    //Enemy���� ���� ���� ���� �÷��̾ �ִ��� üũ.
    //�Ѿ� ��ũ��Ʈ �߻�.
    void Check_your_arget()
    {
        if(Vector2.Distance(transform.position,TarGet.transform.position) < ranges)
        {
            TarGetCk();
            Shooting();
        }
    }
    void Shooting()
    {
        if (Shooting_Cooltime <= 0) 
        {
            Instantiate(Bolat,transform.position, transform.rotation);
            Shooting_Cooltime = 2f;
        }
    }

}
