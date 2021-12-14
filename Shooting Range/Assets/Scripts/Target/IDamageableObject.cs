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
public interface Ibreakable // targetBoard;
{
    void Revive();
}
public interface IHealable // Human copy 
{
    void Heal();
}
public interface IReviveable
{
    void Revive();
}