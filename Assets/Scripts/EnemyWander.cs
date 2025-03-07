using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    public float wanderRadius = 10f;     // How far the enemy can roam
    public float wanderTimer = 3f;       // Time between random movements

    private NavMeshAgent agent;          // Reference to the NavMeshAgent
    private float timer;                 // Timer to track movement intervals

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
        timer = wanderTimer;                 // Initialize the timer
    }

    void Update()
    {
        timer += Time.deltaTime;

        // When the timer hits the wander interval, pick a new random destination
        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavMeshLocation(wanderRadius);
            agent.SetDestination(newPos);   // Move to the new random position
            timer = 0;                      // Reset the timer
        }
    }

    // Get a random point on the NavMesh within a radius
    Vector3 RandomNavMeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius; // Random point in a sphere
        randomDirection += transform.position;                     // Offset it to the enemy's current position

        NavMeshHit hit;                                             // NavMesh hit data
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            return hit.position;                                    // Return the valid position
        }
        return transform.position;                                  // Fallback: stay in the current position
    }
}
