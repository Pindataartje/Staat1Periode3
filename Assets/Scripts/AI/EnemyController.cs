using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; // Player's transform
    public NavMeshAgent agent;
    public bool isActive = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            Debug.LogError("Target is not assigned to the EnemyController script!");
        }
    }

    void Update()
    {
        if (!isActive)
            return;

        // Set the destination to the player's position
        agent.SetDestination(target.position);
    }
}