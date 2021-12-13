using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon;
    private void Start()
    {
        selectedWeapon = 0;
        SwitchWeapon();
    }
    private void Awake()
    {
        PlayerInput.OnSwitch += SelectWeapon;
    }
    private void OnDestroy()
    {
        PlayerInput.OnSwitch -= SelectWeapon;
    }

    private void SelectWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetKeyDown(KeyCode.W)) // observer eklenecek
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
