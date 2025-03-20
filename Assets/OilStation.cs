using UnityEngine;

public class OilStation : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerInventory.Instance.hasOilContainer)
        {
            PlayerInventory.Instance.RefillOilContainer();
        }
    }
}
