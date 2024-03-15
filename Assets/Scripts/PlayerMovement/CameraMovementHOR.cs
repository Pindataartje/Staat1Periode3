using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementHOR : MonoBehaviour
{
    public Vector3 rotatedir;
    public float mouseX;
    public float mouseY;
    public float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X"); //Hiermee koppelen we de float aan de Input van de horizontale muis beweging
        rotatedir.y = mouseX; //Hier koppelen we de Y as van de vector 3 aan de float MouseX
        transform.Rotate(rotatedir * Time.deltaTime * rotatespeed);
        // Hiermee roteren we het object over de Y as die gekoppeld staat aan de mouseX float op basis van de rotatespeed + time.deltatime. 
    }
}
