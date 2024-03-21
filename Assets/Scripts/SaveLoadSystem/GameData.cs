using UnityEngine;

[System.Serializable]
public class GameData
{
    // Player position
    public Vector3 position;
    // Player rotation
    public Quaternion rotation;

    // Constructor to initialize player data
    public GameData(Vector3 playerPosition, Quaternion playerRotation)
    {
        position = playerPosition; // Assigning method parameter to class field without 'this.'
        rotation = playerRotation; // Assigning method parameter to class field without 'this.'
    }
}