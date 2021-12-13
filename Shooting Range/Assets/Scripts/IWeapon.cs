using System.Collections;
using UnityEngine;

public interface IFireable
{
    void Fire();
}
public interface IRecoilable
{
    void Recoil(Vector3 vector);
    void CalculateRecoil(float returnSpeed, float snappiness);
}
public interface IReloadable
{
    IEnumerator Reload();
}