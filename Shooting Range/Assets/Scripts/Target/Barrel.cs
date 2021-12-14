using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : DamageableObject, IExplodeable
{
    public GameObject explodeBarrel;
    public GameObject solidBarrel;
    public ParticleSystem explodeEffect;


    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (CurrentHp <= 0)
        {
            Explode();
        }
    }
    public void Explode()
    {
        solidBarrel.SetActive(false);
        explodeBarrel.SetActive(true);
        explodeEffect.Play();
        //patlama sesi
    }
}
