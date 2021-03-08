using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] allWeps; 
    public GameObject CurrentWep;
    private int GunDamage = 1;
    private float FireRate = 0.05f;
    private float Range = 50f;
    private float Hitforce = 100f;
    private Vector3 originalPos;
    private Vector3 aimingPos;
    private float AdsSpeed;
    private float reloadSpeed;

    public Camera fpsCamera;
    private WaitForSeconds ShotDuration = new WaitForSeconds(0.05f);
    public GameObject startpoint;
    public LineRenderer LaserLine;
    private float nextFire;

    public GameObject AmmoCountContainer;
    public int CurAmmocount = 0;
    public int MaxAmmocount = 0;

    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        AmmoCountContainer = GameObject.Find("Ammo Counter Container");
        allWeps = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weps in allWeps) {
            weps.SetActive(false);
        }
        allWeps[0].SetActive(true);
        LaserLine = GetComponent<LineRenderer>();
        fpsCamera = GetComponentInChildren<Camera>();
        CurrentWep = allWeps[0];
        GetWepStats(CurrentWep);
        

        startpoint = GameObject.Find("FirePoint");

        CurAmmocount = MaxAmmocount;
    }

    // Update is called once per frame
    void Update()
    {

        //ADS
        if (Input.GetMouseButton(1) && canFire)
        {
            CurrentWep.transform.localPosition = Vector3.Lerp(CurrentWep.transform.localPosition, aimingPos, Time.deltaTime * AdsSpeed);
        }
        else {
            CurrentWep.transform.localPosition = Vector3.Lerp(CurrentWep.transform.localPosition, originalPos, Time.deltaTime * AdsSpeed);
        }

        //Firing
        while (Input.GetMouseButton(0) && (Time.time > nextFire) && (CurAmmocount > 0) && canFire) {
            nextFire = Time.time + FireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayorigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            LaserLine.SetPosition(0, startpoint.transform.position);
            if (Physics.Raycast(rayorigin, fpsCamera.transform.forward, out hit, Range))
            {
                LaserLine.SetPosition(1, hit.point);
                Vector3 ray = hit.point - rayorigin;
                if (hit.rigidbody != null) {
                    hit.rigidbody.AddForce(ray.normalized * Hitforce);
                }
                GetComponent<DecalController>().SpawnDecal(hit);
            }
            else {
                LaserLine.SetPosition(1, rayorigin + (fpsCamera.transform.forward * Range));
            }
            CurAmmocount--;
            AmmoCountContainer.GetComponent<AmmoUpdater>().UpdateUI();
        }
        //Weapon Swapping
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SwapWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.R) && (CurAmmocount != MaxAmmocount)) {
            StartCoroutine(ReloadEffect());
            
        }

    }

    private IEnumerator ShotEffect() {
        LaserLine.enabled = true;
        yield return ShotDuration;
        LaserLine.enabled = false;
    }

    private IEnumerator ReloadEffect() {
        Debug.Log("Reloading...");
        canFire = false;
        AmmoCountContainer.GetComponent<AmmoUpdater>().reloadingDisplay.enabled = true;
        yield return new WaitForSeconds(reloadSpeed);
        CurAmmocount = MaxAmmocount;
        AmmoCountContainer.GetComponent<AmmoUpdater>().UpdateUI();
        canFire = true;
        AmmoCountContainer.GetComponent<AmmoUpdater>().reloadingDisplay.enabled = false;
    }
    

    private void SwapWeapon(int WepNumber) {
        CurrentWep.GetComponent<GunStats>().CurAmmoCount = CurAmmocount;
        switch (WepNumber) {
            case 1:
                CurrentWep.SetActive(false);
                CurrentWep = allWeps[0];
                CurrentWep.SetActive(true);
                GetWepStats(CurrentWep);
                break;
            case 2:
                CurrentWep.SetActive(false);
                CurrentWep = allWeps[1];
                CurrentWep.SetActive(true);
                GetWepStats(CurrentWep);
                break;
            default:
                Debug.Log("Switch Statment Failed");
                break;
        }
        startpoint = GameObject.Find("FirePoint");
    }
    private void GetWepStats(GameObject WepPrefab) {
       GunDamage = WepPrefab.GetComponent<GunStats>().GunDamage;
        Range = WepPrefab.GetComponent<GunStats>().Range;
        FireRate = WepPrefab.GetComponent<GunStats>().FireRate;
        Hitforce = WepPrefab.GetComponent<GunStats>().Hitforce;
        originalPos = WepPrefab.GetComponent<GunStats>().originalPos;
        aimingPos = WepPrefab.GetComponent<GunStats>().aimingPos;
        AdsSpeed = WepPrefab.GetComponent<GunStats>().AdsSpeed;
        CurAmmocount = WepPrefab.GetComponent<GunStats>().CurAmmoCount;
        MaxAmmocount = WepPrefab.GetComponent<GunStats>().MaxAmmocount;
        AmmoCountContainer.GetComponent<AmmoUpdater>().UpdateUI();
        reloadSpeed = WepPrefab.GetComponent<GunStats>().reloadSpeed;
    }

   
}
