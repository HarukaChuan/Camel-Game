using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "New Item";

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Add the item to the player's inventory
            PlayerInventory.Instance.AddItem(this);

            // Destroy the item object to make it disappear
            Destroy(gameObject);
        }
    }
}
