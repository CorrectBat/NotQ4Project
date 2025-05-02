using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<ItemNames> itemReq;
    public DuckColors color;
    public TailShapes shape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AssignColor(DuckColors color)
    {
        this.color = color;
    }

    public void AssignItems(List<ItemNames> items) {
        itemReq = items;
    }
    public void AssignTailShape(TailShapes tailShape)
    {
        shape = tailShape;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
