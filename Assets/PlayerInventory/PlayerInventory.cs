using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    private List<Item> items = new List<Item>();  // List of collected items
    public bool hasKey = false;  // Track if the player has the key
    public bool hasOilContainer = false;  // Track if the player has the oil container
    public bool isOilContainerFull = false;  // Track if the oil container is full

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");

        // Update player status based on the item collected
        if (item.CompareTag("Key"))
        {
            hasKey = true;
        }
        else if (item.CompareTag("OilContainer"))
        {
            hasOilContainer = true;
        }

        // Call to update interaction text after adding the item
        InteractionText.Instance.UpdateInteractionText();  // Using the Singleton of InteractionText
    }

    public void RefillOilContainer()
    {
        if (hasOilContainer)
        {
            isOilContainerFull = true;
            Debug.Log("Oil container refilled.");
            InteractionText.Instance.UpdateInteractionText();  // Updating text after refill
        }
    }

    public void ClearInventory()
    {
        items.Clear();
        hasKey = false;
        hasOilContainer = false;
        isOilContainerFull = false;
    }
}
