using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 lopen;
    public float speed;
    public float crouchSpeedMultiplier = 0.5f; // Multiplier for crouch speed
    public bool isCrouching = false; // Flag to track crouch state
    public float standingHeight = 1.0f; // Original height of the player
    public float crouchingHeight = 0.5f; // Height of the player when crouching
    public float standingCheckDistance = 0.2f; // Distance to check for obstacles when standing up
    private CapsuleCollider playerCollider; // Reference to the player's collider

    void Start()
    {
        // Get reference to the player's collider
        playerCollider = GetComponent<CapsuleCollider>();
        // Ensure the collider is not null
        if (playerCollider == null)
        {
            Debug.LogError("Player Collider is missing!");
        }
    }

    void Update()
    {
        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching)
        {
            // Check if there's something above preventing standing up
            RaycastHit hit;
            if (!Physics.Raycast(transform.position + Vector3.up * (standingHeight - 0.1f), Vector3.up, out hit, standingCheckDistance))
            {
                isCrouching = true;
                // Adjust player height when crouching
                playerCollider.height = crouchingHeight;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
        {
            // Restore original player height when standing up
            isCrouching = false;
            playerCollider.height = standingHeight;
        }

        // Handle movement
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        // Apply crouching speed multiplier if crouching
        float currentSpeed = isCrouching ? speed * crouchSpeedMultiplier : speed;

        lopen.x = hor;
        lopen.z = vert;

        transform.Translate(lopen * currentSpeed * Time.deltaTime);
    }
}
