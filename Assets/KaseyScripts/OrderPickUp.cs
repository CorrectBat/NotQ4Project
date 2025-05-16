using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPickUp : MonoBehaviour
{
    public GameObject orderUIPrefab; // Assign inactive prefab in Inspector
    public Transform spawnParent; // UI panel to spawn under
    public List<GameObject> spawnedOrders = new List<GameObject>();

    private float orderOffset = 175f; // Offset between orders
    private int orderCount = 0; // Tracks how many orders have been spawned

    public void ShowOrder(Order order, string customerName)
    {
        if (orderUIPrefab == null)
        {
            Debug.LogError("Order UI Prefab not assigned!");
            return;
        }

        Vector3 basePosition = new Vector3(150f, 775f, 0f);
        basePosition.x += orderCount * orderOffset;

        GameObject newOrderUI = Instantiate(orderUIPrefab, basePosition, Quaternion.identity, spawnParent);
        newOrderUI.SetActive(true);
        Debug.Log("Order UI prefab instantiated at position: " + basePosition);

        Text[] texts = newOrderUI.GetComponentsInChildren<Text>(true); // 'true' includes inactive children
        bool foundTail = false, foundCustomer = false;

        foreach (Text text in texts)
        {
            Debug.Log("Found text field: " + text.name);

            if (text.name == "ColorText")
            {
                text.text = "Color: " + order.color.ToString();
            }
            else if (text.name == "TailText") // updated from "ShapeText"
            {
                text.text = "Tail: " + order.tail.ToString();
                foundTail = true;
            }
            else if (text.name == "AccessoriesText")
            {
                text.text = "Accessories: " + order.ItemToString();
            }
            else if (text.name == "CustomerName") // updated from "CustomerNameText"
            {
                text.text = customerName;
                foundCustomer = true;
            }
        }

        if (!foundTail) Debug.LogError("TailText not found in prefab!");
        if (!foundCustomer) Debug.LogError("CustomerName not found in prefab!");

        spawnedOrders.Add(newOrderUI);
        orderCount++; // increment for spacing
    }

    public void HideAllOrders()
    {
        foreach (var ui in spawnedOrders)
        {
            Destroy(ui);
        }
        spawnedOrders.Clear();
        orderCount = 0; // reset spacing counter
    }
}
