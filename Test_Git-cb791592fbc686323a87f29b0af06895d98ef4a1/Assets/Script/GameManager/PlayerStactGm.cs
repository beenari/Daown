using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStactGm : MonoBehaviour
{
    public static PlayerStactGm PGm;

    [Header("Speed")]
    public float Speed;
    public float MaxSpeed = 5;
    [Header("Jump")]
    public float JumPower = 3;
    public int JumpCount;
    public int MaxJumpCount = 1;
    [Header("Stanamer")]
    public float Stanamer;
    public float MaxStanamer = 10;
    public float hellStanamer;

    [Header("Hp")]
    public float Hp;
    public float MaxHp;
    [Header("Cheack Turn")]
    public int TurnRight;

    [Header("Damage")]
    public int Damage;
    public void Awake()
    {
        PGm = this;
        Speed = MaxSpeed;
        Stanamer = MaxStanamer; JumpCount = MaxJumpCount;
        Hp = MaxHp;
        hellStanamer = 0.1f;
        TurnRight = 1;

    }
}
