using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<ItemNames> itemReq;
    public DuckColors color;
    public TailShapes tail;

    // Assign values manually in inspector OR call this function during setup
    public void AssignReqs(List<ItemNames> items, DuckColors duckColor, TailShapes tailshape)
    {
        itemReq = items;
        color = duckColor;
        tail = tailshape;
        Debug.Log("Order assigned with Color: " + color + ", Tail: " + tail + ", Items: " + ItemToString());
    }

    public string ItemToString()
    {
        if (itemReq == null || itemReq.Count == 0)
        {
            return "No accessories";
        }
        return string.Join(", ", itemReq);
    }
}