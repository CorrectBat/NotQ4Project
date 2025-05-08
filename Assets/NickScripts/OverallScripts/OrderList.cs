using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public List<Order> orders;

    // Start is called before the first frame update
    public void Start()
    {
        orders = new List<Order>();
    }

    public void AddOrder(Order order) 
    {
        Instantiate(order);
        order.AssignColor(DuckColors.blue);
        List<ItemNames> items = new List<ItemNames>();
        order.AssignItems(items);
        order.AssignTailShape(TailShapes.tiny);
        orders.Add(order);
    }

        
}
