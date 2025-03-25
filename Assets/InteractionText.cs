using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionText : MonoBehaviour
{
    public TextMeshProUGUI interactionText;  // Reference to the TextMeshProUGUI object for interaction text
    private float textDisplayDuration = 2f;  // Time to display text
    public static InteractionText Instance;  // Singleton reference for easier access

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // Set the instance
        }
        else
        {
            Destroy(gameObject);  // Prevent multiple instances
        }

        if (interactionText == null)
        {
            Debug.LogError("InteractionText UI is not assigned in the Inspector!");
        }
    }

    // Show the given interaction text and then hide it after the duration
    public void ShowText(string text)
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(true);  // Enable the text UI
            interactionText.text = text;  // Set the text to display

            // Start the coroutine to hide the text after a certain time
            StartCoroutine(HideTextAfterDelay());
        }
        else
        {
            Debug.LogError("InteractionText is not assigned in the scene!");
        }
    }

    // Coroutine to hide the text after a specified duration
    private IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(textDisplayDuration);  // Wait for the specified duration
        interactionText.gameObject.SetActive(false);  // Hide the text
    }

    // Update the interaction text based on the player's inventory (key, oil container)
    public void UpdateInteractionText()
    {
        if (interactionText != null)
        {
            // Determine which message should be shown based on inventory state
            if (PlayerInventory.Instance.hasKey && !PlayerInventory.Instance.hasOilContainer)
            {
                ShowText("I have the key, but I still need the oil container.");
            }
            else if (PlayerInventory.Instance.hasOilContainer && !PlayerInventory.Instance.isOilContainerFull)
            {
                ShowText("I have the oil container, but it is empty! I need to fill it.");
            }
            else if (PlayerInventory.Instance.hasKey && PlayerInventory.Instance.hasOilContainer && !PlayerInventory.Instance.isOilContainerFull)
            {
                ShowText("I have the key and oil container, but I still need to fill the oil container.");
            }
            else if (PlayerInventory.Instance.hasKey && PlayerInventory.Instance.isOilContainerFull)
            {
                ShowText("The oil container is full! Ready to drive!");
            }
            else if (PlayerInventory.Instance.hasOilContainer && PlayerInventory.Instance.isOilContainerFull)
            {
                ShowText("The oil container is already full! I still need the key.");
            }
            else
            {
                ShowText("I still need to find the key and fill the oil container.");
            }
        }
        else
        {
            Debug.LogError("InteractionText is not assigned!");
        }
    }
}
