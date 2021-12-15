using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableTarget : DamageableObject, IBreakable, IDeActiveable
{
    public GameObject solidObj;
    public GameObject breakObj;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (CurrentHp <= 0)
        {
            Break();
            StartCoroutine(DeActive());
        }
    }
    public void Break()
    {
        healBarObj.SetActive(false);
        solidObj.SetActive(false);
        breakObj.SetActive(true);
        //kırılma sesi
    }
    public IEnumerator DeActive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
