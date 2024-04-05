using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject objective1;
    public GameObject objective2;


   private void OnTriggerEnter(Collider other)
    {
        objective1.SetActive(false);
        objective2.SetActive(true);
    }
}
