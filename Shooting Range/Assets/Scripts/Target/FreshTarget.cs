using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreshTarget : DamageableObject, IHealable
{
    private void OnEnable()
    {
        InputManager.OnRevive += Heal;
    }
    private void OnDisable()
    {
        InputManager.OnRevive -= Heal;
    }
    public void Heal()
    {
        Debug.Log(transform.name + " " + maxHp + " değerinde iyileşti");
        healthBar.SetMaxHealth(maxHp);
        CurrentHp = maxHp;
    }
}
