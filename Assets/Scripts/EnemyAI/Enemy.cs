using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints; // Array to hold the waypoints
    public float speed = 3f; // Speed of movement
    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Start()
    {
        // Initialize the starting position
        transform.position = waypoints[currentWaypointIndex].position;
    }

    void Update()
    {
        // Calculate the direction towards the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        // Move towards the current waypoint
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Check if the enemy has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
