using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenertorCode : MonoBehaviour
{
    [Header("������ Hp(�⺻ 20)")]
    public float GenHp = 20;
    //�޾� �;��� ������Ʈ�� : ������ , ���� ��.
    [Header("������� �� ������Ʈ")]
    public GameObject Genertor;//������
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
    void CkGenertor()//�������� �Ѿ�� ���� ����.
    {
        Destroy(Will);
    }
}
