using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemScript : MonoBehaviour
{
    public int keyItemIndex = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.GetComponent<KeyItemsInventoyScript>().KeyItemPickup(keyItemIndex);
        }
    }
}
