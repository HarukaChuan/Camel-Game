using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Inventory count for oil and key
    public int oilCount = 0;
    public int keyCount = 0;

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can add logic here to update the inventory dynamically
    }

    // Method to add items to the inventory (can be used from other scripts)
    public void AddOil(int amount)
    {
        oilCount += amount;
        Debug.Log("Oil Added! Current Oil Count: " + oilCount);
    }

    public void AddKey(int amount)
    {
        keyCount += amount;
        Debug.Log("Key Added! Current Key Count: " + keyCount);
    }

    // Method to check if the player has the required items
    public bool HasRequiredItems()
    {
        return oilCount >= 3 && keyCount >= 1;
    }
}
