using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 lopen;
    public float speed;
    public float runSpeedMultiplier = 2.0f; // Multiplier for run speed
    public bool isRunning = false; // Flag to track run state
    public float standingHeight = 1.0f; // Original height of the player
    public float crouchingHeight = 0.5f; // Height of the player when crouching
    public float maxRunDuration = 10f; // Maximum duration of running in seconds
    private float currentRunDuration = 0f; // Current duration of running
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Check for run input and sufficient duration
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentRunDuration < maxRunDuration)
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || currentRunDuration >= maxRunDuration)
        {
            isRunning = false;
        }

        // Update current run duration
        currentRunDuration += isRunning ? Time.deltaTime : 0f;
        currentRunDuration = Mathf.Clamp(currentRunDuration, 0f, maxRunDuration);

        // Handle movement
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        // Apply speed modifiers
        float currentSpeed = speed;

        
     

        lopen.x = hor;
        lopen.z = vert;

        transform.Translate(lopen * currentSpeed * Time.deltaTime);
        }
}
