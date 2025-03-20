using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float playerinteraction;
    private InteractableObject currentObject;

    void Update()
    {
        CheckInteraction();

        // Check for interaction when 'E' is pressed and an object is detected
        if (Input.GetKeyDown(KeyCode.E) && currentObject != null)
        {
            currentObject.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                InteractableObject newInteractable = hit.collider.GetComponent<InteractableObject>();

                if (newInteractable != null && newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(InteractableObject newInteractable)
    {
        // If there's an already selected object, disable the outline first
        if (currentObject != null)
        {
            DisableCurrentInteractable();
        }

        currentObject = newInteractable;
        //currentObject.EnableOutline(); // Assuming EnableOutline is a method in InteractableObject
    }

    void DisableCurrentInteractable()
    {
        if (currentObject != null)
        {
        //    currentObject.DisableOutline(); // Assuming DisableOutline is a method in InteractableObject
            currentObject = null;
        }
    }
}
