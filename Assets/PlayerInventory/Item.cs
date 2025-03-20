using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName = "New Item";

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory.Instance.AddItem(this);
            Destroy(gameObject);
        }
    }
}
