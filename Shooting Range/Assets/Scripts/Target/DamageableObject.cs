using System;
using UnityEngine;

public abstract class DamageableObject : MonoBehaviour
{
    public float maxHp = 100f;
    private float currentHp;
    protected bool isDead;
    public static event Action<bool> Dead = delegate { };

    public float CurrentHp { get => currentHp; set => currentHp = value; }

    private void Awake()
    {
        CurrentHp = maxHp;
    }
    public virtual void TakeDamage(float amount)
    {
        CurrentHp -= amount;
        Observer();
    }
    public void Observer()
    {
        if (currentHp <= 0 && !isDead)
        {
            isDead = true;
            Dead(isDead);
        }
    }
}
