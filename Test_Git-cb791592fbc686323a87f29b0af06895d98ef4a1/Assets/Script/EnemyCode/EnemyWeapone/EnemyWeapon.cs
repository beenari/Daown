using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{   
    [SerializeField]private GameObject Gun;
    [Header("총알 프리팹")][SerializeField] private GameObject Bolat;
   
    [Header("플레이어 위치값 추적 용도")][SerializeField]private Transform TarGet;
    Vector2 Pos;            //플레이어의 위치를 받아서 저장할 변수.
    Vector2 direction;      //Pos값과,총의 위치의 거리값을 구하는 변수.(정규화)

    private float angel;
    [Header("총알 발사 속도")]
    [SerializeField]private float Shooting_Cooltime =2f;
    [Header("인지 범위")]
    public float ranges =5f;
    [Header("무기")]
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
        회전회오리();

        //Range range = new Range();
    }

    void TarGetCk() //플레이어의 위치를 받은 후 총구를 플레이어를 향하도록  rotation.z 값을 수정.
    {
        Pos = new Vector3(TarGet.transform.position.x, TarGet.transform.position.y);
        direction = (Pos - (Vector2)Gun.transform.position).normalized;

        Gun.transform.right = direction;
    }
    void 회전회오리()
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

    //ENEMy추가해야하루 사항.
    //Enemy들이 일정 범위 내에 플레이어가 있는지 체크.
    //총알 스크립트 발사.
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
