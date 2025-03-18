using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Reference to the player's inventory
    public Inventory playerInventory;

    // Tags for the items (oil and key)
    public string oilTag = "Oil";
    public string keyTag = "Key";

    // When the player collides with an item
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with is the player
        if (other.CompareTag("Player"))
        {
            // Check the tag of the item
            if (CompareTag(oilTag))
            {
                // Add oil to the player's inventory
                playerInventory.AddOil(1);
                Debug.Log("Picked up 1 Oil!");
                
                // Destroy the item after pickup
                Destroy(gameObject);
            }
            else if (CompareTag(keyTag))
            {
                // Add key to the player's inventory
                playerInventory.AddKey(1);
                Debug.Log("Picked up 1 Key!");
                
                // Destroy the item after pickup
                Destroy(gameObject);
            }
        }
    }
}
