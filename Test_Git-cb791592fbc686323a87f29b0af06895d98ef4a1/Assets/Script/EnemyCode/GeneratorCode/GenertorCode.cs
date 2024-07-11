using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenertorCode : MonoBehaviour
{
    [Header("발전기 Hp(기본 20)")]
    public float GenHp = 20;
    //받아 와야할 오브젝트들 : 발전기 , 막을 벽.
    [Header("발전기와 벽 오브젝트")]
    public GameObject Genertor;//발전기
    public GameObject Will;

    public void Damage(float AttakeDamge)
    {
        GenHp -= AttakeDamge;
        if (GenHp <= 0)
        {
            Dead();
            CkGenertor();
        }
    }
    void Dead()
    {
        Destroy(gameObject, 3);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
    void CkGenertor()//다음으로 넘어가는 벽을 제거.
    {
        Destroy(Will);
    }
}
