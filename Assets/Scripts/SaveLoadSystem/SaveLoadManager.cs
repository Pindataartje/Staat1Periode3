using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private static SaveLoadManager instance;

    public static SaveLoadManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveLoadManager>();
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

    public string saveFileName = "playerData.json";

    public void SavePlayerData(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        string savePath = GetSavePath();
        File.WriteAllText(savePath, json);
        Debug.Log("Player data saved successfully. Path: " + savePath);
    }

    public GameData LoadPlayerData()
    {
        string filePath = GetSavePath();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.LogWarning("No save file found.");
            return null;
        }
    }

    private string GetSavePath()
    {
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }
}