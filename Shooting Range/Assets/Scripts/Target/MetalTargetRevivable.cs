using System;
using DG.Tweening;
using UnityEngine;

public class MetalTargetRevivable : DamageableObject, IReviveable
{
    //observer
    public Transform rotatePivot;
    public bool isMoveable;
    private Tween myTween;
    private void OnEnable()
    {
        PlayerInput.OnRevive += Revive;
    }
    private void OnDisable()
    {
        PlayerInput.OnRevive -= Revive;
    }
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
        if (isMoveable)
        {
            myTween = rotatePivot.DOLocalMoveX(rotatePivot.position.x + UnityEngine.Random.Range(1f, 5f), UnityEngine.Random.Range(1f, 2f)).SetLoops(-1, LoopType.Yoyo);
        }

    }
    public void Die()
    {
        rotatePivot.DORotate(new Vector3(rotatePivot.rotation.x, 90, -90f), 0.5f);
        myTween.Pause();
    }
    public void Revive()
    {
        healthBar.SetMaxHealth(maxHp);
        CurrentHp = maxHp;
        if (isDead)
        {
            myTween.Play();
            rotatePivot.DORotate(new Vector3(rotatePivot.rotation.x, 90, 0), 0.5f);
        }

    }
}
