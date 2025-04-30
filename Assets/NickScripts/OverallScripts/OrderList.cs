using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public List<Order> orders;
    public Customer customer;
    // Start is called before the first frame update
    public void Start()
    {
        orders = new List<Order>();
    }

    public void AddOrder(Order order) 
    {
        if (customer.GetName() == "Jason")
            orders.Add(customer.GetOrder());
    }
    public void ChangeCustomer
        
}
