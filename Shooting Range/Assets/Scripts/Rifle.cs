using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    private void OnEnable()
    {
        PlayerInput.OnShootAuto += Shoot;
        PlayerInput.OnReload += ReloadAmmo;
        isReloading = false;
    }
    private void OnDisable()
    {
        PlayerInput.OnShootAuto -= Shoot;
        PlayerInput.OnReload -= ReloadAmmo;
    }
}
