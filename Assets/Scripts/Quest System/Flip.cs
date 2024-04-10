using UnityEngine;

public class Flip : MonoBehaviour
{
    public float maxDistance = 2f; // Maximum distance allowed for flipping
    private Animator mAnimator;
    private Transform playerTransform;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject trigger1;
    public GameObject leftDoorOpen;
    public GameObject rightDoorOpen;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player GameObject
    }

    void Update()
    {
        if (mAnimator != null && playerTransform != null)
        {
            // Calculate the distance between this object and the player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Check if the player is within the maximum distance and pressed the 'E' key
            if (distanceToPlayer <= maxDistance && Input.GetKeyDown(KeyCode.E))
            {
                mAnimator.SetTrigger("Flip");
                objective2.SetActive(false);
                objective3.SetActive(true);
                trigger1.SetActive(false);
                Destroy(leftDoorOpen);
                Destroy(rightDoorOpen);
            }
        }
    }
}