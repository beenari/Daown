using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider Hp_Bar;

    private void Start()
    {
        Hp_Bar.maxValue = PlayerStactGm.PGm.MaxHp;
    }
    void Update()
    {
        Hp_Bar.value = PlayerStactGm.PGm.Hp;
    }
}
