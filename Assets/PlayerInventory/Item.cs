using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "New Item";  // Name of the item (e.g., Key, OilContainer)

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory.Instance.AddItem(this);

            // After item collection, update the interaction text
            CarInteraction carInteraction = collision.gameObject.GetComponent<CarInteraction>();
            if (carInteraction != null)
            {
                carInteraction.UpdateInteractionText();
            }

            Destroy(gameObject);  // Destroy the item after it's collected
        }
    }
}
