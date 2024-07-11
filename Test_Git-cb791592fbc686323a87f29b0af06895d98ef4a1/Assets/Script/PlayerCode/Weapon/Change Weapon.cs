using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour //플레이어 코드
{
    public Transform Shs;
    public GameObject[] Gun;
    public Weapon weapon = Weapon.pistol;

    public GameObject Bolat;
    public enum Weapon
    {
        pistol,

        rocket,

        machine_gun
    }
    private void Start()
    {
        Gun[0].SetActive(true);
        Gun[1].SetActive(false);
        Gun[2].SetActive(false);
    }
    private void Update()
    {
        WeaponChange();
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
            Launch();
    }
    void WeaponChange()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Weapon.pistol;
            Gun[0].SetActive(true);
            Gun[1].SetActive(false);
            Gun[2].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Weapon.rocket;
            Gun[0].SetActive(false);
            Gun[1].SetActive(true);
            Gun[2].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = Weapon.machine_gun;
            Gun[0].SetActive(false);
            Gun[1].SetActive(false);
            Gun[2].SetActive(true);
        }
    }
    void Launch()   
    { 
        if (weapon == Weapon.pistol)
        {
            PlayerStactGm.PGm.Damage = 3;
            Instantiate(Bolat, transform.position,transform.rotation);
        }
        if(weapon == Weapon.rocket)
        {
            PlayerStactGm.PGm.Damage = 5;
            Instantiate(Bolat, transform.position, transform.rotation);
        }
        if(weapon == Weapon.machine_gun)
        {
            PlayerStactGm.PGm.Damage = 2;
            StartCoroutine(Machine_Gun());
        }
    }

    IEnumerator Machine_Gun()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Instantiate(Bolat, transform.position, transform.rotation);
        }
    }
}
