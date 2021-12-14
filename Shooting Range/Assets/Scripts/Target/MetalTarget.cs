using UnityEngine;
using DG.Tweening;

public class MetalTarget : DamageableObject, IKillable, IReviveable
{
    //observer
    public Transform rotatePivot;

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        if (CurrentHp <= 0)
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
        CurrentHp = maxHp;
    }
}
