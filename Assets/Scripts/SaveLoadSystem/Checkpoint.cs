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
        saveLoadManager = Object.FindFirstObjectByType<SaveLoadManager>();
        // Print foutmelding als SaveLoadManager niet gevonden is
        if (saveLoadManager == null)
        {
            Debug.LogError("Checkpoint: SaveLoadManager niet gevonden in de scène.");
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
        // Zorg ervoor dat SaveLoadManager niet null is voordat u probeert spelergegevens op te slaan
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