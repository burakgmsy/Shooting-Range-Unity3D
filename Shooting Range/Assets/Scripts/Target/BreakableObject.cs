using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : DamageableObject, IBreakable
{
    public GameObject solidObj;
    public GameObject breakObj;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (CurrentHp <= 0)
        {
            Break();
        }
    }
    public void Break()
    {
        solidObj.SetActive(false);
        breakObj.SetActive(true);
        //kırılma sesi
    }
}
