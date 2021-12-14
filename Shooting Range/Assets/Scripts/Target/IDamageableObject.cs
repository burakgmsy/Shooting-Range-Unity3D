using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable // targetBoard;
{
    void Die();
}
public interface IExplodeable // barrle and gas tanks
{
    void Explode();
}
public interface IBreakable // targetBoard;
{
    void Break();
}
public interface IHealable // Human copy 
{
    void Heal();
}
public interface IReviveable
{
    void Revive();
}
public interface IDeActiveable
{
    IEnumerator DeActive();
}