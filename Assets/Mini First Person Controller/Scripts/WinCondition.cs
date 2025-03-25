using UnityEngine;
using TMPro;
using System.Collections;

public class CarInteraction : MonoBehaviour
{
    public PlayerInventory playerInventory;  // Reference to the player's inventory
    public TextMeshProUGUI interactionText;  // Reference to the TextMeshProUGUI object for interaction text
    public string playerTag = "Player";  // Player tag to identify the player

    private bool gameStarted = false;  // Track whether the game has started or not

    // Method to start the introduction text after the main menu disappears
    public void StartIntroductionText()
    {
        // Start with the introductory text
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Ugh, I got crashed here...";  // First text
        }

        // Wait for a key press to proceed with the next text
        StartCoroutine(WaitForKeyPress("I need to find my keys and some oil for my car"));
    }

    private IEnumerator WaitForKeyPress(string nextText)
    {
        // Wait for the player to press any key or move
        yield return new WaitUntil(() => Input.anyKeyDown || playerInventory.hasKey || playerInventory.hasOilContainer);

        // After a key is pressed, show the next text for 2 seconds
        interactionText.text = nextText;
        
        // Wait for 2 seconds before allowing the player to click again
        yield return new WaitForSeconds(2f);

        // Now, allow the next interaction
        StartCoroutine(WaitForKeyPressAfterDelay("Next text after 2 seconds"));
    }

    private IEnumerator WaitForKeyPressAfterDelay(string nextText)
    {
        // Wait for a key press or any interaction before moving forward
        yield return new WaitUntil(() => Input.anyKeyDown || playerInventory.hasKey || playerInventory.hasOilContainer);

        interactionText.gameObject.SetActive(false);
        gameStarted = true;

        // Hide the current text after 2 seconds, move to the next stage
        interactionText.gameObject.SetActive(false);
    }

    // Update the interaction text based on the player's inventory (key, oil container)
    public void UpdateInteractionText()
    {
        if (!gameStarted) return;  // Ensure the game has started before showing messages

        if (playerInventory.hasKey && !playerInventory.isOilContainerFull)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "I got the key! Now I need to fill the oil container.";
            StartCoroutine(HideTextAfterDelay());  // Hide text after 2 seconds
        }
        else if (playerInventory.hasOilContainer && !playerInventory.isOilContainerFull)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "I have the oil container, but it's empty! I need the key.";
            StartCoroutine(HideTextAfterDelay());  // Hide text after 2 seconds
        }
        else if (playerInventory.isOilContainerFull)
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "The container is full now. Ready to go!";
            StartCoroutine(HideTextAfterDelay());  // Hide text after 2 seconds
        }
        else
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "I still need to find the key and fill the oil container.";
            StartCoroutine(HideTextAfterDelay());  // Hide text after 2 seconds
        }
    }

    // Coroutine to hide the text after 2 seconds
    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(2f);  // Wait for 2 seconds
        interactionText.gameObject.SetActive(false);  // Hide the text
    }
}
