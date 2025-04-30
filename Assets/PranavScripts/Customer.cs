using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string Name;
    public Order order;

    // Update is called once per frame
    public string GetName()
    {
        return name;
    }
    public Order GetOrder()
    {
        return order;
    }
}
