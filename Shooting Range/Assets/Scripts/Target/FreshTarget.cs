using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshTarget : DamageableObject, IHealable
{
    private void OnEnable()
    {
        PlayerInput.OnRevive += Heal;
    }
    private void OnDisable()
    {
        PlayerInput.OnRevive -= Heal;
    }
    public void Heal()
    {
        healthBar.SetMaxHealth(maxHp);
        CurrentHp = maxHp;
    }
}