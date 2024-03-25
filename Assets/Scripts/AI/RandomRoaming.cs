using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class RandomRoaming : MonoBehaviour
{
    public float roamRadius = 10f;
    public float roamInterval = 2f;
    public NavMeshAgent agent;
    public Vector3 randomDestination;
    public bool isActive = true;
    private float nextRoamTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (isActive && Time.time >= nextRoamTime)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        randomDestination = hit.position;
        agent.SetDestination(randomDestination);
        nextRoamTime = Time.time + roamInterval;
    }
}