using System.Collections.Generic;
using UnityEngine;

public class OrderList : MonoBehaviour
{
<<<<<<< HEAD
    public Customer currentCustomer;
    public CustomerManager customerManager;

    private List<Order> activeOrders = new List<Order>();

    public void SetCurrentCustomer(Customer customer)
=======
    List<Order> orders;

    // Start is called before the first frame update
    void Start()
>>>>>>> 2b12f31e00d436595e45ce1bf2380524995baa4d
    {
        currentCustomer = customer;
        customer.isReadyToOrder = true;
        Debug.Log("Set current customer: " + customer.name);
        Debug.Log("Customer set: " + customer.name);
    }

<<<<<<< HEAD
    public void AddOrder()
    {
        if (currentCustomer != null && currentCustomer.isReadyToOrder)
        {
            Order order = currentCustomer.GetOrder();

            if (order != null)
            {
                activeOrders.Add(order);
                Debug.Log("Order added: " + order);

                currentCustomer.isReadyToOrder = false;
                currentCustomer = null;

                // Start next customer after delay
                customerManager.OnOrderTaken();
            }
            else
            {
                Debug.LogWarning("Customer order is empty!");
            }
        }
        else
        {
            Debug.LogWarning("No customer is ready to order!");
        }
    }

    public List<Order> GetActiveOrders()
    {
        return activeOrders;
    }
=======
    void AddOrder(Order order) {
        orders.Add(order);
    }

    
>>>>>>> 2b12f31e00d436595e45ce1bf2380524995baa4d
}
