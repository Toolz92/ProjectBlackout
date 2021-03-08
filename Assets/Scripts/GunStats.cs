using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStats : MonoBehaviour
{
    public int GunDamage = 1;
    public float FireRate = 0.05f;
    public float Range = 50f;
    public float Hitforce = 100f;
    public Vector3 originalPos;
    public Vector3 aimingPos;
    public float AdsSpeed = 100;
    public int MaxAmmocount = 36;
    public int CurAmmoCount = 36;
    public float reloadSpeed = 1;

    public void Start()
    {
        //originalPos = transform.position;
    }
}
