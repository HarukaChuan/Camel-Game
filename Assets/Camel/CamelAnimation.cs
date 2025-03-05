using UnityEngine;

public class CamelAnimation : MonoBehaviour
{
    private Animator animator; // Reference to Animator component
    private CamelAI camelAI; // Reference to CamelAI component

    void Start()
    {
        // Get the Animator component attached to the camel
        animator = GetComponent<Animator>();

        // Find the camel GameObject using the "Camel" tag
        GameObject camel = GameObject.FindWithTag("Camel");

        if (camel != null)
        {
            // Try to get the CamelAI component from the camel GameObject
            camelAI = camel.GetComponent<CamelAI>();

            // Check if CamelAI is found
            if (camelAI == null)
            {
                Debug.LogError("CamelAI component not found on the camel GameObject with tag 'Camel'!");
            }
        }
        else
        {
            Debug.LogError("No GameObject with the 'Camel' tag found!");
        }
    }

    void Update()
    {
        // Ensure camelAI is valid before trying to access CurrentSpeed
        if (camelAI != null)
        {
            // Update the animator's Speed parameter based on the CamelAI's current speed
            animator.SetFloat("Speed", camelAI.CurrentSpeed);
        }
    }
}
