using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    public PlayerInventory playerInventory;  // Reference to the player's inventory
    public GameObject winPanel;  // The UI panel for the win menu
    private bool isPlayerColliding = false;  // Track if the player is colliding with the car

    // Start is called before the first frame update
    void Start()
    {
        if (playerInventory == null)
        {
            playerInventory = PlayerInventory.Instance;
            if (playerInventory == null)
            {
                Debug.LogError("PlayerInventory instance is not assigned!");
            }
        }

        if (winPanel != null)
        {
            winPanel.SetActive(false);  // Initially, hide the win panel
        }
    }

    // Called when the player collides with the car
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with the car (ensure the player has the tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true; // Player is colliding with the car
            CheckWinCondition(); // Check the win condition right after the collision
        }
    }

    // Called when the player stops colliding with the car
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false; // Player is no longer colliding with the car
        }
    }

    // Check if the win condition is met when the player collides with the car
    private void CheckWinCondition()
    {
        if (isPlayerColliding && playerInventory.hasKey && playerInventory.isOilContainerFull)
        {
            // If both conditions are met, show the win panel
            ShowWinPanel();  // Show the win panel
        }
    }

    // Show the win panel
    private void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);  // Activate the win panel
        }
        else
        {
            Debug.LogError("Win Panel is not assigned!");
        }
    }
}
