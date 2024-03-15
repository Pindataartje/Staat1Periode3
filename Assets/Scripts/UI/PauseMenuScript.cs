using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;
    public string mainMenuSceneName = "MainMenu";


    void Start()
    {
        // Ensure the pause menu canvas is initially deactivated
        pauseMenuCanvas.SetActive(false);

        // Check if the game is not initially paused
        if (!isPaused)
        {
            // Hide and lock the cursor only if the game is not paused
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        // Check for the ESC key to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        // Toggle the pause state
        isPaused = !isPaused;

        // Activate/deactivate the pause menu canvas accordingly
        pauseMenuCanvas.SetActive(isPaused);

        // Pause or unpause the game time
        Time.timeScale = isPaused ? 0f : 1f;

        // Toggle cursor visibility and lock state based on pause state
        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Function to resume the game when the "Resume" button is clicked
    public void ResumeGame()
    {
        // Set isPaused to false and hide the pause menu canvas
        isPaused = false;
        pauseMenuCanvas.SetActive(false);

        // Resume the game time
        Time.timeScale = 1f;

        // Restore cursor visibility and lock state
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}