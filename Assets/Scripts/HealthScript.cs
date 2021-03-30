using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth = 100f;
    public float regenAmount = 3f;
    public float regenSpeed = 1f;
    public float regenDelay = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        if (currentHealth == maxHealth) {
            CancelInvoke("Regeneration");
        }
        //Damage Testing Code
        if (Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(50);
        }
    }

    public void TakeDamage(float Damage) {
        currentHealth -= Damage;
        CancelInvoke("Regeneration");
        InvokeRepeating("Regeneration", regenDelay, regenSpeed);
        if (currentHealth <= 0 && (this.tag != "Player")) {
            this.gameObject.SetActive(false);
        }
    }

    public void Regeneration() {
        currentHealth += regenAmount;
    }
}
