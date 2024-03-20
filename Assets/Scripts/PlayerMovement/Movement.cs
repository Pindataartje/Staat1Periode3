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

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        // Check for crouch input
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            // Adjust player height when crouching
            transform.localScale = new Vector3(transform.localScale.x, crouchingHeight, transform.localScale.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            // Restore original player height when standing up
            transform.localScale = new Vector3(transform.localScale.x, standingHeight, transform.localScale.z);
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