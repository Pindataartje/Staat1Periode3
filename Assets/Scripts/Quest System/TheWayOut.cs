using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheWayOut : MonoBehaviour
{
    public GameObject doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(doorOpen);
    }

}
