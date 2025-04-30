using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryDuck : MonoBehaviour
{
    List<ItemNames> items;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<ItemNames>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Item") {
            items.Add(collision.transform.GetComponent<AccessoryItem>().GetItem());
            Debug.Log(collision.transform.GetComponent<AccessoryItem>().GetItem());
        }
    }

    public List<ItemNames> GetItems() {
        return items;
    }
}
