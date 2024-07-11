using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorial_BoosCode : MonoBehaviour
{
    public GameObject[] BigGun;
    public GameObject[] barrier;
    public GameObject SliderBar;
    [Header("���Ⱑ �̵��ؾ� �� ����Ʈ")]
    public GameObject[] BoosPotiton;
    private void Awake()
    {
        SliderBar.SetActive(false);
        BigGun[0].SetActive(false);
        BigGun[1].SetActive(false);
        BigGun[2].SetActive(false);

        barrier[0].SetActive(false);
        barrier[1].SetActive(false);
    }
    void Update()
    { 
        if(CameraChangeGm.CmGm.booszone)
        {
            barrier[0].SetActive(true);
            barrier[1].SetActive(true);
            barrier[0].transform.position = Vector3.MoveTowards(barrier[0].transform.position, BoosPotiton[2].transform.position, 0.6f);
            barrier[1].transform.position = Vector3.MoveTowards(barrier[1].transform.position, BoosPotiton[3].transform.position, 0.6f);
        }
        if (TutoralBoosStactGm.TbGm.BoosPlay)
        {
            if(TutoralBoosStactGm.TbGm.Hp > 200)
                Page_1();
            else Page_2();
        }
        if(TutoralBoosStactGm.TbGm.Hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        SliderBar.SetActive(false);
        Debug.Log("���� �� ��Ͽ� �� ���̳�~");
        this.enabled = false;
        Destroy(barrier[1]);
    }
    void Page_1()
    {
        Debug.Log("1��");
        if (BigGun[1].transform.position != BoosPotiton[1].transform.position)
            Move_Gun();
        else Debug.Log("�ح�");
    }

    void Move_Gun()
    {
        SliderBar.SetActive(true);
        BigGun[0].SetActive(true);
        BigGun[1].SetActive(true);
        BigGun[0].transform.position = Vector3.MoveTowards(BigGun[0].transform.position, BoosPotiton[0].transform.position, 0.2f);
        BigGun[1].transform.position = Vector3.MoveTowards(BigGun[1].transform.position, BoosPotiton[1].transform.position, 0.2f);
    }
    void Page_2()//ü���� 3���� 2�� �������
    {
        Debug.Log("2��");
        //��� �� ģ�� �Ʒ� �ڵ� ����

        if (BigGun[2].transform.position != BoosPotiton[4].transform.position)
            Move_Gun_2();

    }
    void Move_Gun_2()
    {
        BigGun[2].SetActive(true);
        BigGun[2].transform.position = Vector3.MoveTowards(BigGun[2].transform.position, BoosPotiton[4].transform.position, 0.8f);
    }
}
