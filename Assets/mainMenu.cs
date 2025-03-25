using UnityEngine;
using UnityEngine.UI;  // For the Button

public class MainMenu : MonoBehaviour
{
    // Reference to the button in the UI
    public Button startButton;

    // Reference to the canvas for the Main Menu
    public Canvas mainMenuCanvas;

    // Reference to the CarInteraction script to trigger the introduction text
    public CarInteraction carInteractionScript;

    void Start()
    {
        // Ensure the button triggers the method when clicked
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonPressed);
        }

        // Unlock and show the cursor so the player can interact with the UI
        UnlockCursor();

        // Ensure the Main Menu Canvas is visible
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.gameObject.SetActive(true);
        }

        // Pause the game at the start (stop everything)
        PauseGame();
    }

    void Update()
    {
        // Check if "Enter" key is pressed for starting the game
        if (Input.GetKeyDown(KeyCode.Return))  // You can replace KeyCode.Return with another key if needed
        {
            OnStartButtonPressed();
        }
    }

    // Start the game when the start button is pressed
    void OnStartButtonPressed()
    {
        // Debugging
        Debug.Log("Start Button Pressed");

        // Hide the main menu and start the game
        StartCoroutine(HideMainMenuAndStartGame());
    }

    private System.Collections.IEnumerator HideMainMenuAndStartGame()
    {
        // Hide the main menu
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.gameObject.SetActive(false);  // Hide the main menu
        }

        // Unpause the game and continue gameplay
        ResumeGame();

        // Lock and hide the cursor when the game starts
        LockCursor();

        // Now trigger the introduction sequence (start the CarInteraction script)
        if (carInteractionScript != null)
        {
            // Start the introduction text sequence after the main menu is hidden
            carInteractionScript.StartIntroductionText();
        }

        // No scene is being loaded anymore, game continues from this point
        yield return null;  // This just ensures the transition happens in the next frame
    }

    // Pauses the game
    private void PauseGame()
    {
        Time.timeScale = 0; // Pauses the game, stopping all gameplay mechanics, animations, etc.
    }

    // Resumes the game
    private void ResumeGame()
    {
        Time.timeScale = 1; // Resumes the game, everything is active again
    }

    // Unlocks the cursor
    private void UnlockCursor()
    {
        Debug.Log("Unlocking Cursor");  // Debugging log
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Make the cursor visible
    }

    // Locks the cursor to the center and hides it
    private void LockCursor()
    {
        Debug.Log("Locking Cursor");  // Debugging log
        Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center
        Cursor.visible = false;  // Hide the cursor
    }
}
