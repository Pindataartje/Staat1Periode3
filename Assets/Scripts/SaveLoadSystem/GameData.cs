using UnityEngine;

[System.Serializable]
public class GameData
{
    // Positie van de speler
    public Vector3 position;
    // Rotatie van de speler
    public Quaternion rotation;

    // Constructor om speler data te initialiseren
    public GameData(Vector3 position, Quaternion rotation)
    {
        this.position = position;
        this.rotation = rotation;
    }
}