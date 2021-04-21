using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform.position, Vector3.up);
        this.transform.forward = Camera.main.transform.forward;
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
    }

    public void Disable() {
        this.gameObject.SetActive(false);
    }
}
