using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour, IFireable, IRecoilable, IReloadable
{

    [SerializeField] private WeaponType weaponType = null;
    [SerializeField] public bool isReloading = false;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem muzzleFlash;
    public int shootCounter;

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
        GameManager.Instance.DisplayAmmo(weaponType.currentAmmo, weaponType.maxAmmo);
        if (!isReloading)
        {
            GameManager.Instance.DisplayReloading(null);
        }
    }
    public void ReloadAmmo()
    {
        if (weaponType.currentAmmo < weaponType.maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }

    }
    public IEnumerator Reload()
    {
        Debug.Log("Şarjör Dolduruluyor...");
        GameManager.Instance.DisplayReloading("Reloading..");
        isReloading = true;
        yield return new WaitForSeconds(weaponType.reloadTime);
        Debug.Log("Şarjör Dolduruldu");
        weaponType.currentAmmo = weaponType.maxAmmo;
        isReloading = false;
        GameManager.Instance.DisplayReloading(null);
    }

    public void Shoot()
    {
        if (weaponType.currentAmmo > 0 && Time.time >= weaponType.nextTimeToFire && !isReloading)
        {
            weaponType.nextTimeToFire = Time.time + 1f / weaponType.fireRate;
            Fire();
        }
    }
    public void Fire()
    {
        muzzleFlash.Play();
        weaponType.currentAmmo--;
        shootCounter++;
        Debug.Log("Ateş Edildi");

        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, weaponType.range))
        {
            //Debug.Log(hit.transform.name);
            DamageableObject target = hit.transform.GetComponent<DamageableObject>();
            if (target != null)
            {
                target.TakeDamage((int)weaponType.damage);
                Debug.Log("Hedef Vuruldu");
            }
            else
            {
                Debug.Log("Hedef Vurulmadı");
                Debug.Log(hit.transform.name + " Vuruldu");
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
