using UnityEngine;
using System.Collections;

public class RandomLightScript : MonoBehaviour
{
    public Light[] lights; // Lights controlled by this script
    public GameObject enemy; // Enemy with the trigger collider

    private bool playerInEnemyRange = false;

    void Start()
    {
        StartCoroutine(RandomLightToggle());
    }

    IEnumerator RandomLightToggle()
    {
        while (true)
        {
            if (playerInEnemyRange)
            {
                // Toggle lights only if player is in range of the enemy
                ToggleLights();
            }

            yield return new WaitForSeconds(Random.Range(0f, 1.5f)); // Random delay between light toggles
        }
    }

    void ToggleLights()
    {
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            // Player entered the enemy's trigger collider
            playerInEnemyRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            // Player exited the enemy's trigger collider
            playerInEnemyRange = false;
        }
    }
}