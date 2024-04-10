using UnityEngine;

[System.Serializable]
public class GameData
{
    // Player position
    public Vector3 position;
    // Player rotation
    public Quaternion rotation;

    // Constructor om spelergegevens te initialiseren
    public GameData(Vector3 playerPosition, Quaternion playerRotation)
    {
        position = playerPosition; 
        rotation = playerRotation; 
    }
}