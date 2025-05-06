using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    List<Order> orders;

    // Start is called before the first frame update
    void Start()
    {
        orders = new List<Order>();
    }

    void AddOrder(Order order) {
        orders.Add(order);
    }

    
}
