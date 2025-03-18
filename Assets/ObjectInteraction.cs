using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Camera playerCamera;
    private RaycastHit hit;
    public float interactionDistance = 3f;
    public Color rayColor = Color.red; // Color of the ray (can be set in Inspector)

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        // Check for left mouse click (Mouse0)
        if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button
        {
            // Perform a raycast from the camera's position based on the mouse position
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            
            // Draw the ray for visualization (only in the Scene view, not in-game)
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance, rayColor, 100f); // 2f is the duration the ray stays visible in the scene view
            
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                // Check if the ray hit an interactable object
                if (hit.collider.CompareTag("Interactable"))
                {
                    // Try to get the InteractableObject component on the hit object
                    InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                    if (interactable != null)
                    {
                        interactable.Interact(); // Call the Interact method from InteractableObject
                    }
                }
            }
        }
    }
}
