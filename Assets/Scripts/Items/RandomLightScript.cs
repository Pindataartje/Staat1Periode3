using UnityEngine;
using System.Collections;

public class RandomLightScript : MonoBehaviour
{
    public GameObject lightObject; // Drag your light game object here in the inspector

    void Start()
    {
        StartCoroutine(RandomLight());
    }

    IEnumerator RandomLight()
    {
        while (true)
        {
            float delay = Random.Range(0f, 1.5f); // Generate a random delay between 0 and 5 seconds
            yield return new WaitForSeconds(delay);

            // Toggle the light on and off
            lightObject.SetActive(!lightObject.activeSelf);
        }
    }
}