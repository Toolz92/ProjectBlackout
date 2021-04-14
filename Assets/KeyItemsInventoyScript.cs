using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemsInventoyScript : MonoBehaviour
{
    public bool[] keyItems;
    public int numOfKeyItems = 1;
        //Add to this list as more key items are added
        //0 = key
        
    // Start is called before the first frame update
    void Start()
    {
        keyItems = new bool[numOfKeyItems];
    }

    public void KeyItemPickup(int index) {
        keyItems[index] = true;
    }

    public bool KeyItemCheck(int index) {
        if (keyItems[index]) {
            return true;
        }
        return false;
    }

    
   
}
