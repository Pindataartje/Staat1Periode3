using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public GameObject objective2;
    public GameObject objective3;
    public GameObject trigger1;
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            objective2.SetActive(false);
            objective3.SetActive(true);
            trigger1.SetActive(false);
        }
    }

}
