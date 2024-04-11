using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 lopen;
    public float speed;
    public float standingHeight = 1.0f; // Original height of the player
    public float crouchingHeight = 0.5f; // Height of the player when crouching
    public float maxRunDuration = 10f; // Maximum duration of running in seconds
   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     
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
