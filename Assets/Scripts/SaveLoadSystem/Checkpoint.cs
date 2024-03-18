using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Referentie naar SaveLoadManager
    public SaveLoadManager saveLoadManager;

    // Vind SaveLoadManager instantie
    void Start()
    {
        saveLoadManager = FindObjectOfType<SaveLoadManager>();
        // Print foutmelding als SaveLoadManager niet gevonden is
        if (saveLoadManager == null)
        {
            Debug.LogError("Checkpoint: SaveLoadManager niet gevonden in de sc�ne.");
        }
    }

    // Wordt aangeroepen wanneer speler de checkpoint-zone betreedt
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sla speler data op
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