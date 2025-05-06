using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private List<ItemNames> itemReq;
    private DuckColors color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void AssignReqs(List<ItemNames> items, DuckColors duckColor) {
        itemReq = items;
        color = duckColor;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
