using UnityEngine;

public class DeathCanvas : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject deathCanvas;
    public PauseMenuScript pauseMenuScript; // Reference to PauseMenuScript

    private void Start()
    {
        // Ensure both canvases are initially turned off
        winCanvas.SetActive(false);
        deathCanvas.SetActive(false);
        pauseMenuScript.HideAndLockCursor(); // Ensure cursor is initially hidden and locked
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Add this line
        if (collision.collider.CompareTag("Win"))
        {
            ActivateWinCanvas();
        }
        // Other collision handling code...
        if (collision.collider.CompareTag("Death"))
        {
            ActivateDeathCanvas();
        }
    }

    private void ActivateWinCanvas()
    {
        // Turn off the death canvas (if it's active) and activate the win canvas
        deathCanvas.SetActive(false);
        winCanvas.SetActive(true);
        pauseMenuScript.ShowAndUnlockCursor(); // Show and unlock cursor when canvas is activated
    }

    private void ActivateDeathCanvas()
    {
        // Turn off the win canvas (if it's active) and activate the death canvas
        winCanvas.SetActive(false);
        deathCanvas.SetActive(true);
        pauseMenuScript.ShowAndUnlockCursor(); // Show and unlock cursor when canvas is activated
    }
}