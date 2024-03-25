using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public EnemyController controller;
    public RandomRoaming randomRoaming;

    void Start()
    {
        // Initially, activate roaming and deactivate targeting
        controller.isActive = false;
        randomRoaming.isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // No need to manually enable/disable, handled through isActive variables
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if collided with the SaveZone collider
        if (other.CompareTag("Kamer"))
        {
            // Activate roaming and deactivate targeting
            Debug.Log("Entered Kamer. Activating Roaming and deactivating Targeting.");
            controller.isActive = false;
            randomRoaming.isActive = true;
        }
        // Check if collided with the Gang collider
        else if (other.CompareTag("Gang"))
        {
            // Activate targeting and deactivate roaming
            Debug.Log("Entered Gang. Activating Targeting and deactivating Roaming.");
            controller.isActive = true;
            randomRoaming.isActive = false;
        }
    }
}