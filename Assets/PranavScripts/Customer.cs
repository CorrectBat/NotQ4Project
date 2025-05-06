using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order order;
    public bool isReadyToOrder = false;

    public Order GetOrder()
    {
        return order;
    }
}
