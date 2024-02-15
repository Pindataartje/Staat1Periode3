using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public RaycastHit hit;
    public float raycastdistance;
    public Canvas interactCanvas; // Reference to the canvas object

    void Start()
    {
        // Disable the canvas at the start
        interactCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // Draw the raycast line for debugging purposes
        Debug.DrawRay(transform.position, transform.forward * raycastdistance, Color.red);

        // Een raycast wordt aangemaakt die voorwaards gaat vanaf de positie van het object.
        // Het resultaat van de raycast wordt opgeslagen in de RaycastHit variable.
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastdistance))
        {
            // Hier checken we of het geraakte object van de raycast de onderstaande tag bevat
            if (hit.transform.CompareTag("Note"))
            {
                // Hier checken we of de "E" knop wordt ingedrukt
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Activate the canvas
                    interactCanvas.gameObject.SetActive(true);
                    Debug.Log("Canvas activated");
                }
            }
        }
        else
        {
            // Deactivate the canvas if no object is hit
            interactCanvas.gameObject.SetActive(false);
        }
    }
}
