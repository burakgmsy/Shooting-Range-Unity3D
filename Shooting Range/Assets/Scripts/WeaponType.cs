using UnityEngine;



[CreateAssetMenu(fileName = "New Weapon Type", menuName = "Weapon Type")]
public class WeaponType : ScriptableObject
{
    public string weaponName;
    //Dakikada 400 atış--iki kurşun arası vakit;
    //otomatik atış
    public float nextTimeToFire;
    public float damage;
    public float reloadTime;
    public int maxAmmo;
    public int currentAmmo;
    public float range;
    public float impactForce;
    public float fireRate;

    public Vector3 recoilVector;
    public float snappiness;
    public float returnSpeed;
}
