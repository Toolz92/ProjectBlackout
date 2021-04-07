using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickupScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<HealthScript>().Armorrefill();
            this.gameObject.SetActive(false);
        }
    }

}
