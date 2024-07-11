using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class CameraChangeGm : MonoBehaviour
{
    public static CameraChangeGm CmGm;

    private void Start()
    {
        CmGm = this;
    }

    public bool booszone;

    [Header("플레이어 위치값")]
    public Transform TarGet;
    [Header("메인 카메라")]
    public Camera Camera;
    public GameObject FollowerObg;

    [Header("위치 고정 축")]
    public Transform[] pos;
    private void Update()
    {
        ChangeCameraSize();
    }
    private void ChangeCameraSize()
    {
        int CollisionLayer = LayerMask.GetMask("CameraZone");
        RaycastHit2D hit = Physics2D.Raycast(TarGet.transform.position, Vector2.zero,Mathf.Infinity,CollisionLayer);
        if(hit.collider != null)
        {
            switch(hit.collider.gameObject.tag)
            {
                case "originalZone":
                    Camera.orthographicSize = 5;
                    break;
                case "BigZone":
                    Camera.orthographicSize = 8;
                    break;
                case "BoosZone":
                    Camera.orthographicSize = 10.5f;
                    booszone = true;
                    FollowerObg.transform.position = pos[0].position;
                    break;

            }
        }
        else
        {
            booszone = false;
        }
    }
}
