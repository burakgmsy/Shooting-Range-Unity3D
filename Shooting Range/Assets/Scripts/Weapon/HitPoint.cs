using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public GameObject metalHitEffect;
    public GameObject stoneHitEffect;
    public GameObject woodHitEffect;
    public GameObject sandHitEffect;
    public GameObject[] fleshHitEffects;


    private void Start()
    {
        Weapon.HitListener += HandleHit;
    }
    private void OnDestroy()
    {
        Weapon.HitListener -= HandleHit;
    }


    void HandleHit(RaycastHit hit)
    {
        if (hit.collider.sharedMaterial != null)
        {
            string materialName = hit.collider.sharedMaterial.name;

            switch (materialName)
            {
                case "Metal":
                    SpawnDecal(hit, metalHitEffect);
                    break;
                case "Stone":
                    SpawnDecal(hit, stoneHitEffect);
                    break;
                case "Wood":
                    SpawnDecal(hit, woodHitEffect);
                    break;
                case "Meat":
                    SpawnDecal(hit, fleshHitEffects[Random.Range(0, fleshHitEffects.Length)]);
                    break;
                case "Sand":
                    SpawnDecal(hit, sandHitEffect);
                    break;
                default:
                    //SpawnDecal(hit,defoutEffect)
                    break;
            }
        }
    }

    void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
        spawnedDecal.transform.SetParent(hit.collider.transform);
    }

}
