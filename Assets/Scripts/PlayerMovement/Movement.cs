using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 lopen;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Set the player GameObject reference when the script starts
        SetPlayerObjectReference();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        lopen.x = hor;
        lopen.z = vert;

        transform.Translate(lopen * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision infoAboutWhatIHit)
    {
        if (infoAboutWhatIHit.gameObject.tag == "MovingBlock")
        {
            print("Boem");
        }
    }

    // Method to set the player GameObject reference
    private void SetPlayerObjectReference()
    {
        // Find the player GameObject in the scene and store its reference
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");

        // Check if the player GameObject reference is valid
        if (playerGameObject != null)
        {
            // Get a reference to the PersistentManager
            PersistentManager persistentManager = FindObjectOfType<PersistentManager>();

            // Set the player GameObject reference in the PersistentManager
            if (persistentManager != null)
            {
                persistentManager.SetPlayerObject(playerGameObject);
            }
            else
            {
                Debug.LogWarning("PersistentManager not found in the scene.");
            }
        }
        else
        {
            Debug.LogWarning("Player GameObject not found in the scene.");
        }
    }
}