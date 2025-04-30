using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public Customer currentCustomer; // This is the one currently placing an order
    private List<Order> activeOrders = new List<Order>(); // Orders in progress

    public void SetCurrentCustomer(Customer customer)
    {
        currentCustomer = customer;
        currentCustomer.isReadyToOrder = true;
    }

    public void AddOrder()
    {
        if (currentCustomer != null && currentCustomer.isReadyToOrder)
        {
            Order order = currentCustomer.GetOrder();

            if (order != null)
            {
                activeOrders.Add(order);
                Debug.Log("Order added: " + order);

                // Mark customer as no longer ordering
                currentCustomer.isReadyToOrder = false;
                currentCustomer = null;
            }
            else
            {
                Debug.LogWarning("Current customer has no order set!");
            }
        }
        else
        {
            Debug.LogWarning("No customer is ready to order.");
        }
    }
}
