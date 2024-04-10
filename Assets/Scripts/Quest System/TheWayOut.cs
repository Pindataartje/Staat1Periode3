using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheWayOut : MonoBehaviour
{
    public GameObject leftDoorOpen;
    public GameObject rightDoorOpen;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(leftDoorOpen);
        Destroy(rightDoorOpen);
    }

}
