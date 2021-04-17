using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool Triggered;
    public Animator anim;
    private void Update()
    {
        if (Triggered) {
        

            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("OpenClose");
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            anim = other.GetComponentInChildren<Animator>();
            Triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Triggered = false;
            anim = null;
        }
    }
}
