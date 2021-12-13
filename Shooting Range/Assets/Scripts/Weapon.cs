using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, IFireable, IRecoilable, IReloadable
{
    [SerializeField] private WeaponType weaponType = null;
    [SerializeField] public bool isReloading = false;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem muzzleFlash;

    //RECOİL
    private Vector3 currentRotation;
    private Vector3 targetRotation;
    public Transform recoilObject;

    public static event Action<RaycastHit> HitListener;

    private void Start()
    {
        //currentAmmo = maxAmmo;
        weaponType.nextTimeToFire = 0;
        weaponType.currentAmmo = weaponType.maxAmmo;
    }
    private void Update()
    {
        CalculateRecoil(weaponType.snappiness, weaponType.returnSpeed);
    }
    public void ReloadAmmo()
    {
        if (weaponType.currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }
    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(weaponType.reloadTime);
        //currentAmmo = maxAmmo;
        weaponType.currentAmmo = weaponType.maxAmmo;
        isReloading = false;
    }

    public void Shoot()
    {
        if (weaponType.currentAmmo > 0 && Time.time >= weaponType.nextTimeToFire)
        {
            weaponType.nextTimeToFire = Time.time + 1f / weaponType.fireRate;
            Fire();
        }
    }
    public void Fire()
    {
        muzzleFlash.Play();
        weaponType.currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, weaponType.range))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(weaponType.damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * weaponType.impactForce);
            }

            HitListener?.Invoke(hit);
            Recoil(weaponType.recoilVector);
        }
    }

    public void Recoil(Vector3 vector)
    {
        targetRotation += new Vector3(vector.x, UnityEngine.Random.Range(-vector.y, vector.y), UnityEngine.Random.Range(-vector.z, vector.z));
    }

    public void CalculateRecoil(float returnSpeed, float snappiness)
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.fixedDeltaTime);
        recoilObject.localRotation = Quaternion.Euler(currentRotation);
    }


}
