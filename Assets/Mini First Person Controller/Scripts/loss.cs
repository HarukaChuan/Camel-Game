using UnityEngine;

public class CamelCollision : MonoBehaviour
{
    // Reference to the loss menu script to show the loss screen
    public LossMenu lossMenuScript;

    // When the camel collides with the player, stop the game and show the loss screen
    private void OnCollisionEnter(Collision other)
    {
        // Check if the object collided with is the player
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision detected with Player!");  // Debugging line

            // Stop the game
            Time.timeScale = 0;  // Pauses the game

            // Call the ShowLossMenu method from the LossMenu script
            if (lossMenuScript != null)
            {
                lossMenuScript.ShowLossMenu();  // This will activate the loss menu
                Debug.Log("Game Over! Loss screen activated.");  // Debugging line
            }
            else
            {
                Debug.LogWarning("LossMenu script reference is missing!");  // Warn if the script is not assigned
            }

            // Unlock the cursor and make it visible when the loss screen is displayed
            UnlockCursor();
        }
    }

    // Method to unlock the cursor and make it visible
    private void UnlockCursor()
    {
        Debug.Log("Unlocking Cursor");
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Make the cursor visible
    }
}
