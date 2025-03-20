using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    private List<Item> items = new List<Item>();
    public bool hasKey = false;
    public bool hasOilContainer = false;
    public bool isOilContainerFull = false;

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

        if (item.CompareTag("Key"))
        {
            hasKey = true;
        }
        else if (item.CompareTag("OilContainer"))
        {
            hasOilContainer = true;
        }
    }

    public void RefillOilContainer()
    {
        if (hasOilContainer)
        {
            isOilContainerFull = true;
            Debug.Log("Oil container refilled.");
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
