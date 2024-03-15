using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    // Singleton instance
    private static PersistentManager instance;

    // Reference to the player GameObject
    private GameObject playerObject;

    // Ensure only one instance of PersistentManager exists
    private void Awake()
    {
        // If an instance already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton
        instance = this;

        // Make this GameObject persistent between scenes
        DontDestroyOnLoad(gameObject);

        // Log the player object reference
        Debug.Log("Player GameObject reference assigned: " + playerObject);
    }

    // Method to set the player GameObject reference
    public void SetPlayerObject(GameObject player)
    {
        playerObject = player;
    }

    // Method to retrieve the player GameObject reference
    public GameObject GetPlayerObject()
    {
        return playerObject;
    }

    // Method to destroy the singleton instance
    public static void DestroyInstance()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }
}