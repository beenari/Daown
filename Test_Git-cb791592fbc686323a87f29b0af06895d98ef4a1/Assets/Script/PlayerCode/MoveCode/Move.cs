using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rd;
    private CapsuleCollider2D capsuleCollider2D;


    [SerializeField] private LayerMask GroundLayer;
    private bool Grounded;
    private bool willedLeft;
    private bool willedRight;

    private Vector3 footPosition;//바닥 닿았는지 위치값 구함.
    private Vector3 footPositionclimbingLeft;
    private Vector3 footPositionclimbingRight;

    private void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rd = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        JumpCk();
        float x = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Runing(x);
        }
        else
        {
            Moveing(x);
        }
        //climbing(x);
        TurnCheack();
        if(Input.GetKeyDown(KeyCode.Space)&& PlayerStactGm.PGm.JumpCount > 0)
        {
            Jumping();
            PlayerStactGm.PGm.JumpCount--;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Dead();
        }
        if(PlayerStactGm.PGm.Hp < 0)
            Dead();
    }
    void Moveing(float x)
    {
        rd.velocity = new Vector2(x * PlayerStactGm.PGm.Speed, rd.velocity.y);
    }
    void Jumping()
    {
        rd.velocity = Vector2.up * PlayerStactGm.PGm.JumPower;
    }
    void JumpCk()
    {
        Bounds bounds = capsuleCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        Grounded = Physics2D.OverlapCircle(footPosition, 0.1f, GroundLayer);

        if (Grounded == true && rd.velocity.y <= 0)
            PlayerStactGm.PGm.JumpCount = PlayerStactGm.PGm.MaxJumpCount;
    }
    //void climbing(float x)
    //{
    //    Bounds bounds = capsuleCollider2D.bounds;
    //    footPositionclimbingLeft = new Vector2(bounds.min.x,bounds.center.y);   //좌측 충돌 감지
    //    footPositionclimbingRight = new Vector2(bounds.max.x,bounds.center.y);  //우측 충돌 감지

    //    willedLeft = Physics2D.OverlapCircle(footPositionclimbingLeft, 0.1f, GroundLayer);
    //    willedRight = Physics2D.OverlapCircle(footPositionclimbingRight,0.1f,GroundLayer);

    //    if (willedLeft == true || willedRight == true) // 벽에 붙어있을시 안 떨어지게 하기위해.
    //        rd.gravityScale = 0;
    //    else rd.gravityScale = 1;

    //    if (willedLeft == true && x < 0)        //A누를떄
    //    {
    //        rd.velocity = Vector2.up * PlayerStactGm.PGm.Speed * -x;
    //    }
    //    else if (willedRight == true && x > 0)  //D누를떄
    //    {
    //        rd.velocity = Vector2.up * PlayerStactGm.PGm.Speed * x;
    //    }
    //}
    void Runing(float x)
    {
        rd.velocity = new Vector2(x * PlayerStactGm.PGm.Speed * 1.5f, rd.velocity.y);
    }
    void TurnCheack()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerStactGm.PGm.TurnRight = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerStactGm.PGm.TurnRight = 1;
        }
        if (PlayerStactGm.PGm.TurnRight == -1)
        {
            Turn(-180);
        }
        else if (PlayerStactGm.PGm.TurnRight == 1)
        {
            Turn(0);
        }
    }
    void Turn(int y)
    {
        Vector3 Rotation = new Vector3(transform.rotation.x, y, transform.rotation.z);
        transform.rotation = Quaternion.Euler(Rotation);
    }
    private void Dead()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
