using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable // metalTarget; 
{
    void Die();
}
public interface IExplodeable // barrle and gas tanks
{
    void Explode();
}
public interface IBreakable // Mug and plate;
{
    void Break();
}
public interface IHealable // Human copy 
{
    void Heal();
}
public interface IReviveable // MetalTarget
{
    void Revive();
}
public interface IDeActiveable // barrle and gas tanks
{
    IEnumerator DeActive();
}