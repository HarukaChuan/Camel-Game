using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemType; // "Oil" or "Key" to identify the item type

    private Inventory playerInventory;

    void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // This method will be called when the player interacts with the object
    public void Interact()
    {
        if (itemType == "Oil")
        {
            playerInventory.AddOil(1); // Add 1 oil to the inventory
            Debug.Log("Picked up 1 Oil!");
        }
        else if (itemType == "Key")
        {
            playerInventory.AddKey(1); // Add 1 key to the inventory
            Debug.Log("Picked up 1 Key!");
        }

        // Disable the object (make it disappear)
        gameObject.SetActive(false);
    }
}
