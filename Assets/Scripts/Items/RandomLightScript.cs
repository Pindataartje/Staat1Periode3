using UnityEngine;
using System.Collections;

public class RandomLightScript : MonoBehaviour
{
    public Light lightComponent; // Drag your Light component here in the inspector

    void Start()
    {
        StartCoroutine(RandomLight());
    }

    IEnumerator RandomLight()
    {
        while (true)
        {
            float delay = Random.Range(0f, 1.5f); // Generate a random delay between 0 and 1.5 seconds
            yield return new WaitForSeconds(delay);

            // Toggle the light intensity on and off
            lightComponent.enabled = !lightComponent.enabled;
        }
    }
}