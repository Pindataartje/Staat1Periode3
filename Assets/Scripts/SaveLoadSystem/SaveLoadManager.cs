using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    // Singleton instantie van SaveLoadManager
    private static SaveLoadManager instance;

    // Haal de instantie van SaveLoadManager op
    public static SaveLoadManager Instance
    {
        get
        {
            // Als de instantie null is, zoek een bestaande instantie of maak een nieuwe aan
            if (instance == null)
            {
                instance = Object.FindFirstObjectByType<SaveLoadManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("SaveLoadManager");
                    instance = singletonObject.AddComponent<SaveLoadManager>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    // Naam van het opslagbestand
    private string saveFileName = "playerData.json";

    // Sla speler data op naar bestand
    public void SavePlayerData(GameData data)
    {
        // Converteer GameData object naar JSON string
        string json = JsonUtility.ToJson(data);
        // Haal opslagpad op
        string savePath = GetSavePath();
        // Schrijf JSON string naar bestand
        File.WriteAllText(savePath, json);
        // Log opslagpad naar console
        Debug.Log("Speler data succesvol opgeslagen. Pad: " + savePath);
    }

    // Laad speler data uit bestand
    public GameData LoadPlayerData()
    {
        // Haal opslagbestandpad op
        string filePath = GetSavePath();
        // Controleer of opslagbestand bestaat
        if (File.Exists(filePath))
        {
            // Lees JSON string uit bestand en converteer het terug naar GameData object
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            // Print waarschuwing als er geen opslagbestand gevonden is
            Debug.LogWarning("Geen opslagbestand gevonden.");
            return null;
        }
    }

    // Haal opslagpad op
    private string GetSavePath()
    {
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }
}