using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoralBoosStactGm : MonoBehaviour
{
    public static TutoralBoosStactGm TbGm;

    public Transform BoosObj;
    private float speed = 2.5f;
    [Header("������ �̵��ؾ� �� ����Ʈ")]
    public GameObject BoosPotiton;
    [Header("������ �����ҋ� Ȯ�ο�")]
    public bool BoosPlay = false;
    [Header("������ �ش� �������� �Դ��� Ȯ�ο�")]
    public bool bosPosCk = false;

    public float Damaged = 1;
    public float Hp = 500f;

    void Start()
    {
        TbGm = this;
    }
    void Update()
    {
        Debug.Log("���� ���� Hp : " + Hp);   
        if(CameraChangeGm.CmGm.booszone)
        {
            if(BoosObj.transform.position == BoosPotiton.transform.position)
            {
                //���丮 ���� �ؽ�Ʈ ����
                //��� ���� ��ٸ� �Ʒ� �Լ� ����
                BoosPlay = true;
                bosPosCk = true;
            }
            else
            {
                BoosObj.transform.position = Vector3.MoveTowards(BoosObj.transform.position, BoosPotiton.transform.position, speed * Time.deltaTime);
            }
        }
    }

    public void Damage(float Attake)
    {
        Hp -= Attake;
    }
}
