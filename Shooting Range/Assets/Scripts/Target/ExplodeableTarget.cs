using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeableTarget : DamageableObject, IExplodeable, IDeActiveable
{
    public GameObject explodeBarrel;
    public GameObject solidBarrel;
    public ParticleSystem explodeEffect;


    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (CurrentHp <= 0)
        {
            Explode();
            StartCoroutine(DeActive());
        }
    }
    public void Explode()
    {
        solidBarrel.SetActive(false);
        explodeBarrel.SetActive(true);
        explodeEffect.Play();
        //patlama sesi
    }

    public IEnumerator DeActive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
