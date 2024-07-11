using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosHpBar : MonoBehaviour
{
    public Slider Hp_Bar;

    private void Start()
    {
        Hp_Bar.maxValue = TutoralBoosStactGm.TbGm.Hp;
    }
    private void Update()
    {
        Hp_Bar.value= TutoralBoosStactGm.TbGm.Hp;
    }
}
