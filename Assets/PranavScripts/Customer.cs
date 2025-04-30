using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public bool isReadyToOrder;
    public Order order;

    // Update is called once per frame
    public Order GetOrder()
    {
        return order;
    }
}
