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
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        HideAndLockCursor(); // Ensure cursor is initially hidden and locked
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        if (isPaused)
        {
            ShowAndUnlockCursor(); // Show and unlock cursor when paused
        }
        else
        {
            HideAndLockCursor(); // Hide and lock cursor when resumed
        }
    }

    // Functie om het spel te hervatten wanneer op de knop "Hervatten" wordt geklikt
    public void ResumeGame()
    {
        // Stel isPaused in op false en verberg het canvas van het pauzemenu
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        HideAndLockCursor(); // Hide and lock cursor when game resumes
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // Method to show and unlock cursor
    public void ShowAndUnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Method to hide and lock cursor
    public void HideAndLockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}