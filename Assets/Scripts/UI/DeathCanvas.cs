using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCanvas : MonoBehaviour
{
    public GameObject retryCanvas;
    public AudioSource audioToMute;
    public bool cursorLocked = true;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Death")
        {
            retryCanvas.SetActive(true);
            GetComponent<AudioSource>().Play();

            audioToMute.volume = 0f;

            // Unlock and show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Set the cursorLocked flag to false
            cursorLocked = false;
        }
    }

    void Update()
    {
        // Check if the cursor should be locked and hidden
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}