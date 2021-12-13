using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageableObject : MonoBehaviour
{
    public float maxHp = 100f;
    protected float currentHp;
    private void Awake()
    {
        currentHp = maxHp;
    }
    public virtual void TakeDamage(float amount)
    {
        currentHp -= amount;
    }
}
