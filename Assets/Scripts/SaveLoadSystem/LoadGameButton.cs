using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    // Naam van de spelscène om te laden
    public string gameSceneName = "MapTest3-25-24"; // Update this with the name of your new scene

    // Functie om het opgeslagen spel en de scène te laden
    public void LoadSavedGameAndScene()
    {
        // Laad de opgeslagen speler data
        GameData savedGameData = SaveLoadManager.Instance.LoadPlayerData();

        // Controleer of opgeslagen speler data bestaat
        if (savedGameData != null)
        {
            // Print geladen speler data naar console
            Debug.Log("Geladen speler data: Positie=" + savedGameData.position + ", Rotatie=" + savedGameData.rotation);

            // Laad de spelscène asynchroon
            if (!string.IsNullOrEmpty(gameSceneName))
            {
                SceneManager.LoadSceneAsync(gameSceneName).completed += (operation) =>
                {
                    // Stel de positie en rotatie van de speler in op basis van de geladen data
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    if (player != null)
                    {
                        player.transform.position = savedGameData.position;
                        player.transform.rotation = savedGameData.rotation;
                    }
                    else
                    {
                        Debug.LogError("LoadGameButton: Speler GameObject niet gevonden in de geladen scène.");
                    }

                    // Print succesbericht naar console
                    Debug.Log("Spel succesvol geladen.");
                };
            }
            else
            {
                Debug.LogError("LoadGameButton: Spelscène naam niet ingesteld.");
            }
        }
        else
        {
            // Print waarschuwing als er geen opgeslagen data gevonden is
            Debug.LogWarning("Kon spel niet laden: Geen opgeslagen data gevonden.");
        }
    }
}