using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void StartNewGame()
    {
        // Define default player position and rotation
        Vector3 defaultPosition = new Vector3(0f, 0f, 0f);
        Quaternion defaultRotation = Quaternion.identity;

        // Create default player data
        GameData defaultPlayerData = new GameData(defaultPosition, defaultRotation);

        // Save default player data
        SaveLoadManager.Instance.SavePlayerData(defaultPlayerData);

        // Load the game scene
        SceneManager.LoadScene("MapXander");
    }
}