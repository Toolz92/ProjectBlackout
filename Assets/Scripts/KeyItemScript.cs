using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemScript : MonoBehaviour
{
    public int keyItemIndex = 0;
    public bool interactable;
    public GameObject Player;

    public Billboard interactUI;

    private void Start()
    {
        interactUI = GetComponentInChildren<Billboard>();
        interactUI.Disable();
    }
    private void Update()
    {
        if (interactable) {
            if (Input.GetKeyDown(KeyCode.F)) {
                Player.GetComponent<KeyItemsInventoyScript>().KeyItemPickup(keyItemIndex);
                this.gameObject.SetActive(false);
            }
        
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Player = other.gameObject;
            interactable = true;
            interactUI.Enable();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player = null;
            interactable = false;
            interactUI.Disable();
        }
    }
}
