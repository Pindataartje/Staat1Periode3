using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCanvas : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject deathCanvas;

    private void Start()
    {
        // Ensure both canvases are initially turned off
        winCanvas.SetActive(false);
        deathCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // Add this line
        if (other.CompareTag("Win"))
        {
            ActivateWinCanvas();
        }
        // Other collision handling code...
        if (other.CompareTag("Death"))
        {
            ActivateDeathCanvas();
        }
    }

    private void ActivateWinCanvas()
    {
        // Turn off the death canvas (if it's active) and activate the win canvas
        deathCanvas.SetActive(false);
        winCanvas.SetActive(true);
    }

    private void ActivateDeathCanvas()
    {
        // Turn off the win canvas (if it's active) and activate the death canvas
        winCanvas.SetActive(false);
        deathCanvas.SetActive(true);
    }
}