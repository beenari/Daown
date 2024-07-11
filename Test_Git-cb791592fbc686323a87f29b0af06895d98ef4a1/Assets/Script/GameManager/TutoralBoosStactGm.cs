using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoralBoosStactGm : MonoBehaviour
{
    public static TutoralBoosStactGm TbGm;

    public Transform BoosObj;
    private float speed = 2.5f;
    [Header("보스가 이동해야 할 포인트")]
    public GameObject BoosPotiton;
    [Header("보스전 시작할떄 확인용")]
    public bool BoosPlay = false;
    [Header("보스가 해당 지점으로 왔는지 확인용")]
    public bool bosPosCk = false;

    public float Damaged = 1;
    public float Hp = 500f;

    void Start()
    {
        TbGm = this;
    }
    void Update()
    {
        Debug.Log("보스 남은 Hp : " + Hp);   
        if(CameraChangeGm.CmGm.booszone)
        {
            if(BoosObj.transform.position == BoosPotiton.transform.position)
            {
                //스토리 진행 텍스트 진행
                //모두 진행 됬다면 아래 함수 실행
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
