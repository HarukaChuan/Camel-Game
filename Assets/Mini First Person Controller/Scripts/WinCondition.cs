using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    // Reference to the WinMenu script to show the win screen
    public WinMenu winMenuScript;

    // Player tag to identify the player (you can change this as needed)
    public string playerTag = "Player";

    // Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with is the player
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Pause the game
            Time.timeScale = 0;
            Debug.Log("Game Paused");

            // Call the ShowWinMenu method from the WinMenu script
            if (winMenuScript != null)
            {
                winMenuScript.ShowWinMenu();  // This will activate the win menu
            }
            else
            {
                Debug.LogWarning("WinMenu script reference is missing!");  // Warn if the script is not assigned
            }

            // Unlock the cursor and make it visible when the win menu is displayed
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
