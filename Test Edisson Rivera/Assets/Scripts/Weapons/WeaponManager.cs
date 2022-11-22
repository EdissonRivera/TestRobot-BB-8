using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] internal GameObject[] weapons;
    int _currentWeapon;
    private void Update()
    {
        Debug.Log("manager");
        if (Input.GetButton("Fire1"))
        {
            weapons[_currentWeapon].GetComponent<ShootPlayer>()._shoot = true;
        }
        else
        {
            weapons[_currentWeapon].GetComponent<ShootPlayer>()._shoot = false;
        }
    }

    public void SetWeapon(int currentWeapon)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[currentWeapon].SetActive(true);
        _currentWeapon = currentWeapon;
    }


}
