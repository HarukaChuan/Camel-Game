using UnityEngine;
using UnityEngine.AI;

public class CamelAI : MonoBehaviour
{
    public enum CamelState
    {
        Idle,
        Running
    }

    public float detectionRadius = 10f; // Detection radius to start chasing
    public float runningSpeed = 4f; // Running speed when chasing the player
    private NavMeshAgent agent;
    private Transform player;
    private CamelState currentState = CamelState.Idle;

    private PlayerInventory playerInventory; // Reference to PlayerInventory
    private bool isChasingPlayer = false; // Flag to track if the camel is chasing the player

    public float CurrentSpeed { get; private set; }

    void Start()
    {
        // Get the NavMeshAgent component attached to the camel
        agent = GetComponent<NavMeshAgent>();

        // Find the player and assign the transform
        player = GameObject.FindWithTag("Player").transform;

        // Get the PlayerInventory script
        playerInventory = player.GetComponent<PlayerInventory>();

        // Set initial agent speed to 0 (idle)
        agent.speed = 0f;

        // Initialize CurrentSpeed
        CurrentSpeed = 0f;
    }

    void Update()
    {
        // Check if the player has all the required inventory items
        if (PlayerHasFullInventory() && !isChasingPlayer)
        {
            StartChasingPlayer(); // Start chasing the player once inventory is complete
        }

        // If camel is chasing player, run toward the player
        if (isChasingPlayer)
        {
            ChangeState(CamelState.Running); // Switch to running state
            agent.SetDestination(player.position); // Move toward the player
        }

        // Update the CurrentSpeed based on the agent's velocity (magnitude)
        CurrentSpeed = agent.velocity.magnitude;

        // Rotate camel towards movement direction
        if (agent.velocity.magnitude > 0.1f)
        {
            Vector3 movementDirection = agent.velocity.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }

    // Check if the player has collected all items (key, oil container, full oil container)
    private bool PlayerHasFullInventory()
    {
        return playerInventory.hasKey && playerInventory.hasOilContainer && playerInventory.isOilContainerFull;
    }

    // Method to start chasing the player
    private void StartChasingPlayer()
    {
        isChasingPlayer = true;

        // Enable the NavMeshAgent and set its speed to running speed
        agent.enabled = true;
        agent.speed = runningSpeed;

        // Start the camel's movement towards the player
        agent.SetDestination(player.position);
    }

    // Change camel's state and adjust speed
    void ChangeState(CamelState newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;

        switch (currentState)
        {
            case CamelState.Idle:
                agent.speed = 0f; // Camel is idle, no movement
                break;
            case CamelState.Running:
                agent.speed = runningSpeed; // Camel is running to chase the player
                break;
        }
    }
}
