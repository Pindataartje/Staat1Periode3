using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void StartNewGame()
    {
        // Start a new game (create new save file)
        SaveLoadManager.Instance.SavePlayerData(CreateDefaultPlayerData());

        // Load the game scene
        SceneManager.LoadScene("MapXander");
    }

    private GameData CreateDefaultPlayerData()
    {
        // Define default player position and rotation
        Vector3 defaultPosition = new Vector3(0f, 0f, 0f);
        Quaternion defaultRotation = Quaternion.identity;

        // Create and return default player data
        return new GameData(defaultPosition, defaultRotation);
    }
}