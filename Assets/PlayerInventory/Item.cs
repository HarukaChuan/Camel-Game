using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "New Item";  // Name of the item (e.g., Key, OilContainer)

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory.Instance.AddItem(this);

            // After item collection, update the interaction text (no need to check for CarInteraction)
            InteractionText.Instance.UpdateInteractionText(); // Direct call to the InteractionText Singleton

            Destroy(gameObject);  // Destroy the item after it's collected
        }
    }
}
