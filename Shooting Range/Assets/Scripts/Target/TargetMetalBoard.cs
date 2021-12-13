using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetMetalBoard : DamageableObject, IKillable, IReviveable
{
    //observer
    public Transform rotatePivot;
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (currentHp <= 0)
        {
            Die();
        }
    }
    private void Start()
    {
        rotatePivot.DORotate(new Vector3(rotatePivot.rotation.x, 90, 0), 0.5f);
    }
    public void Die()
    {
        rotatePivot.DORotate(new Vector3(rotatePivot.rotation.x, 90, -90f), 0.5f);
    }

    public void Revive()
    {
        rotatePivot.DORotate(new Vector3(rotatePivot.rotation.x, 90, 0), 0.5f);
        currentHp = maxHp;
    }
}
