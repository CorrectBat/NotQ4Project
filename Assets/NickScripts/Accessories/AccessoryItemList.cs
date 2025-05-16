using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryItemList : MonoBehaviour
{
    AccessoryItem[] items;
    // Start is called before the first frame update
    void Start()
    {
        items = transform.GetComponentsInChildren<AccessoryItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        foreach(AccessoryItem item in items) {
            //item.ResetItem();
        }
    }
}
