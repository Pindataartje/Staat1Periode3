using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public GameObject deathCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            // Activate the death canvas when colliding with an object tagged as "Death"
            deathCanvas.SetActive(true);
            Debug.Log("Player collided with object tagged as 'Death'");
        }
    }
}