using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Singleton instance
    public static PlayerInventory Instance;

    // List to hold collected items
    private List<Item> items = new List<Item>();

    void Awake()
    {
        // Ensure only one instance of PlayerInventory exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add an item to the inventory
    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
    }

    // Method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        Debug.Log(item.itemName + " removed from inventory.");
    }

    // Method to get the list of items in the inventory
    public List<Item> GetItems()
    {
        return items;
    }
}
