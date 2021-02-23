using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public int GunDamage = 1;
    public float FireRate = 0.05f;
    public float Range = 50f;
    public float Hitforce = 100f;

    public Camera fpsCamera;
    public WaitForSeconds ShotDuration = new WaitForSeconds(0.05f);
    public GameObject startpoint;
    public LineRenderer LaserLine;
    public float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        LaserLine = GetComponent<LineRenderer>();
        fpsCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        while (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
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
        }
    }

    private IEnumerator ShotEffect() {
        LaserLine.enabled = true;
        yield return ShotDuration;
        LaserLine.enabled = false;
    }
   

   
}
