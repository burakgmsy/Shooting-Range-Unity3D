using System;
using UnityEngine;

public abstract class DamageableObject : MonoBehaviour
{
    public int maxHp = 100;
    private int currentHp;
    protected bool isDead;
    public HealthBar healthBar;
    public GameObject healBarObj;
    public static event Action<bool> Dead = delegate { };

    public int CurrentHp { get => currentHp; set => currentHp = value; }

    private void Awake()
    {
        CurrentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);
    }
    public virtual void TakeDamage(int amount)
    {
        currentHp -= amount;
        healthBar.SetHealth(currentHp);
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
