using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SaveLoadManager saveLoadManager;

    void Start()
    {
        // Find the SaveLoadManager instance in the scene
        saveLoadManager = FindObjectOfType<SaveLoadManager>();

        if (saveLoadManager == null)
        {
            Debug.LogError("Checkpoint: SaveLoadManager not found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SavePlayerData(other.transform.position, other.transform.rotation);
        }
    }

    void SavePlayerData(Vector3 position, Quaternion rotation)
    {
        Debug.Log("Saving player data: Position=" + position + ", Rotation=" + rotation);
        // Ensure that SaveLoadManager is not null before attempting to save player data
        if (saveLoadManager != null)
        {
            // Create GameData object
            GameData playerData = new GameData(position, rotation);

            // Save player data
            saveLoadManager.SavePlayerData(playerData);
        }
        else
        {
            Debug.LogError("Checkpoint: SaveLoadManager is not initialized.");
        }
    }
}