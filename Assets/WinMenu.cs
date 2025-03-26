using UnityEngine;
using UnityEngine.SceneManagement;  // For Scene management
using UnityEngine.UI;  // For UI elements

public class WinMenu : MonoBehaviour
{
    // Reference to the win menu UI Canvas (make sure to set this in the Inspector)
    public GameObject winMenuCanvas;

    // Reference to the Restart Button (make sure to set this in the Inspector)
    public Button restartButton;

    void Start()
    {
        // Ensure the win menu is hidden at the start
        if (winMenuCanvas != null)
        {
            winMenuCanvas.SetActive(false);  // Make sure it's disabled initially
        }

        // Set up the button click listener for restarting the game
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);  // Add the RestartGame method to the button's click event
        }
         Time.timeScale = 0; // Pauses the game, stopping all gameplay mechanics, animations, etc.
    }

    void Update()
    {
        // Check if the "Enter" key is pressed for restarting the game
        if (Input.GetKeyDown(KeyCode.Return)) // You can change the key to something else if needed
        {
            RestartGame();
        }
    }

    // Call this method to show the win screen and stop the game
    public void ShowWinMenu()
    {
        if (winMenuCanvas != null)
        {
            winMenuCanvas.SetActive(true);  // Show the win menu UI
        }

        // Unlock the cursor and make it visible so the player can interact with the UI
        UnlockCursor();

        // Pause the game (stop time)
        Time.timeScale = 0;  // Freezes the game
    }

    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1;  // Unfreeze the game (resume normal gameplay)

        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene

        // Lock the cursor and hide it again after restarting
        LockCursor();
    }

    // Method to unlock the cursor so the player can interact with the UI
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Make the cursor visible
    }

    // Method to lock the cursor back to the center and hide it when the game starts
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center
        Cursor.visible = false;  // Hide the cursor
    }
}
