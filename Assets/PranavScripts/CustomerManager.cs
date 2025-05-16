using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public List<GameObject> customers;  // Assign in Inspector
    public OrderList orderManager;   // Reference to OrderManager

    private int currentIndex = 0;

    void Start()
    {
        // Hide all customers except the first one
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].SetActive(i == 0);
        }

        // Set the first customer as ready
        if (customers.Count > 0)
        {
            SetCustomerReady(customers[0]);
        }
    }

    public void OnOrderTaken()
    {
        // Called by OrderManager when an order is taken
        StartCoroutine(WaitAndShowNextCustomer());
    }

    private IEnumerator WaitAndShowNextCustomer()
    {
        // Wait 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide current customer
        if (currentIndex < customers.Count)
        {
            customers[currentIndex].SetActive(false);
        }

        // Move to next customer
        currentIndex++;

        if (currentIndex < customers.Count)
        {
            GameObject nextCustomer = customers[currentIndex];
            nextCustomer.SetActive(true);
            SetCustomerReady(nextCustomer);
        }
        else
        {
            Debug.Log("No more customers!");
        }
    }

    public void SetCustomerReady(GameObject customerGO)
    {
        Customer customer = customerGO.GetComponent<Customer>();
        if (customer != null)
        {
            customer.isReadyToOrder = true;
            orderManager.SetCurrentCustomer(customer);
            Debug.Log("Customer ready: " + customer.name);
        }
    }
}

