using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    public GameObject messageUI;
    public string message = "This is the default message";
    // Start is called before the first frame update
    void Start()
    {
        messageUI = GameObject.Find("MessageDisplay");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        UpdateMessageUI();
    }

    public void UpdateMessageUI() {
        messageUI.SetActive(true);
        messageUI.GetComponent<Text>().text = message;

    }

    private void OnTriggerExit(Collider other)
    {
        messageUI.SetActive(false);
    }
}
