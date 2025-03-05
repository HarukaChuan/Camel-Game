using UnityEngine;
using UnityEngine.AI;

public class CamelAI : MonoBehaviour
{
    public enum CamelState
    {
        Idle,
        Walking,
        Running
    }

    public Transform[] waypoints;
    public float detectionRadius = 10f;
    public float walkingSpeed = 2f;
    public float runningSpeed = 4f;
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private Transform player;
    private CamelState currentState = CamelState.Idle; // Default state

    public float CurrentSpeed { get; private set; } // Expose current speed for other scripts to access

    void Start()
    {
        // Get the NavMeshAgent component attached to the camel
        agent = GetComponent<NavMeshAgent>();

        // Find the player and assign the transform
        player = GameObject.FindWithTag("Player").transform;

        // Set initial agent speed to walking speed
        agent.speed = walkingSpeed;

        // Initialize CurrentSpeed
        CurrentSpeed = walkingSpeed;

        // Rotate the camel 180 degrees to make sure it walks backward.
        transform.Rotate(0, 180, 0); // This will rotate the camel by 180 degrees on the Y-axis.
    }

    void Update()
    {
        // Check if the player is within the detection radius and if there is a clear line of sight
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius && HasLineOfSightToPlayer())
        {
            // Change state to Running
            ChangeState(CamelState.Running);

            // Set the agent's destination to the player's position (moving toward player)
            agent.SetDestination(player.position);
        }
        else
        {
            // If not chasing the player, use waypoints or idle
            if (waypoints.Length > 0)
            {
                ChangeState(CamelState.Walking); // Default to walking when moving through waypoints

                // Check if we are close enough to the current waypoint
                if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= 1f)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }

                // Set the agent's destination to the current waypoint
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
            else
            {
                ChangeState(CamelState.Idle); // Idle if there are no waypoints
            }
        }

        // Update the CurrentSpeed based on the agent's velocity (magnitude)
        CurrentSpeed = agent.velocity.magnitude;

        // Rotate the camel to face the movement direction (it should face the correct way now after rotation)
        if (agent.velocity.magnitude > 0.1f) // Only rotate when moving
        {
            Vector3 movementDirection = agent.velocity.normalized;

            // Rotate the camel to face the movement direction.
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }

    // This method checks if there is a clear line of sight to the player
    bool HasLineOfSightToPlayer()
    {
        RaycastHit hit;
        Vector3 directionToPlayer = player.position - transform.position;

        // Cast a ray towards the player and check if it hits anything other than the player
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRadius))
        {
            if (hit.transform != player) // If the ray hits something other than the player
            {
                return false; // No line of sight
            }
        }
        return true; // Clear line of sight
    }

    void ChangeState(CamelState newState)
    {
        if (currentState == newState)
            return; // No need to change if the state is already the same

        currentState = newState;

        // Adjust agent's speed based on state
        switch (currentState)
        {
            case CamelState.Walking:
                agent.speed = walkingSpeed; // Slow speed for walking
                break;
            case CamelState.Running:
                agent.speed = runningSpeed; // Faster speed for running
                break;
            case CamelState.Idle:
                agent.speed = 0f; // No movement speed when idle
                break;
        }
    }
}
