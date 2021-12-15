using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    private void OnEnable()
    {
        PlayerInput.OnShootSingle += Shoot;
        PlayerInput.OnReload += ReloadAmmo;
        isReloading = false;
    }
    private void OnDisable()
    {
        PlayerInput.OnShootSingle -= Shoot;
        PlayerInput.OnReload -= ReloadAmmo;
        GameManager.Instance.DisplayReloading(null);
    }
}
