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
    public AudioClip walkSound; // Sound effect for walking
    public AudioSource walkAudioSource; // AudioSource component to play walk sound
    private bool isWalking; // Flag to track if the player is walking

    // Start is called before the first frame update
    void Start()
    {
        // Check if an audio clip for walking is provided
        if (walkSound == null)
        {
            Debug.LogWarning("Walk sound effect not assigned.");
        }

        // If walkAudioSource is not assigned, use the AudioSource component attached to this GameObject
        if (walkAudioSource == null)
        {
            walkAudioSource = GetComponent<AudioSource>();
        }
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

        // Check if the player is moving (any movement input value is not zero)
        if (hor != 0 || vert != 0)
        {
            // If the audio clip is assigned and not already playing, play it
            if (!isWalking && walkSound != null)
            {
                walkAudioSource.clip = walkSound;
                walkAudioSource.loop = true;
                walkAudioSource.Play();
                isWalking = true;
            }
        }
        else
        {
            // If no movement keys are pressed, stop playing the audio clip
            walkAudioSource.Stop();
            isWalking = false;
        }
    }
}