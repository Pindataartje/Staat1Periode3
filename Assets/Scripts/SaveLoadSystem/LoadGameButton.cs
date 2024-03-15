using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    public string gameSceneName = "YourGameSceneNameHere";

    public void LoadSavedGameAndScene()
    {
        // Load the saved player data
        GameData savedGameData = SaveLoadManager.Instance.LoadPlayerData();

        if (savedGameData != null)
        {
            Debug.Log("Loaded player data: Position=" + savedGameData.GetPosition() + ", Rotation=" + savedGameData.GetRotation());

            // Load the game scene asynchronously
            SceneManager.LoadSceneAsync(gameSceneName).completed += (operation) =>
            {
                // Set the player's position and rotation based on the loaded data
                SetPlayerPositionAndRotation(savedGameData.GetPosition(), savedGameData.GetRotation());

                Debug.Log("Game loaded successfully.");
            };
        }
        else
        {
            Debug.LogWarning("Failed to load game: No saved data found.");
        }
    }

    private void SetPlayerPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        // Find the player GameObject in the loaded scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Ensure that the player GameObject is not null before setting its position and rotation
        if (player != null)
        {
            player.transform.position = position;
            player.transform.rotation = rotation;
        }
        else
        {
            Debug.LogError("LoadGameButton: Player GameObject not found in the loaded scene.");
        }
    }
}