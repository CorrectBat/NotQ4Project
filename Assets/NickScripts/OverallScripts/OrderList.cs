using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderList : MonoBehaviour
{
    public Customer currentCustomer;
    public CustomerManager customerManager;
    public OrderPickUp orderPickUp;
    public UnityEngine.UI.Button takeOrderButton;

    private List<Order> activeOrders = new List<Order>();
    private Order currentOrder;

    public void SetCurrentCustomer(Customer customer)
    {
        currentCustomer = customer;
        StartCoroutine(RevealTakeOrderButtonAfterDelay());
    }

    private IEnumerator RevealTakeOrderButtonAfterDelay()
    {
        takeOrderButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(6f);
        takeOrderButton.gameObject.SetActive(true);
    }

    public void AddOrder()
    {
        if (currentCustomer != null && currentCustomer.isReadyToOrder)
        {
            Order order = currentCustomer.GetOrder();

            if (order != null)
            {
                activeOrders.Add(order);
                currentOrder = order;

                orderPickUp.ShowOrder(order, currentCustomer.name);
                takeOrderButton.gameObject.SetActive(false);

                currentCustomer.isReadyToOrder = false;
                currentCustomer = null;

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

    public void FulfillOrder()
    {
        if (currentOrder != null)
        {
            activeOrders.Remove(currentOrder);
            orderPickUp.HideAllOrders();
            Debug.Log("Order fulfilled!");
            currentOrder = null;
        }
    }

    public List<Order> GetActiveOrders()
    {
        return activeOrders;
    }
}

