using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoUpdater : MonoBehaviour
{
    public GameObject player;
    public Text curAmmo;
    public Text maxAmmo;
    public Text reloadingDisplay;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        reloadingDisplay.enabled = false;
    }
    public void UpdateUI() {
        curAmmo.text = player.GetComponent<ShootScript>().CurAmmocount.ToString();
        maxAmmo.text = player.GetComponent<ShootScript>().MaxAmmocount.ToString();
    }
    
}
