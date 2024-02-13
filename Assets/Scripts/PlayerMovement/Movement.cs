using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 lopen;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal"); // Hier koppelen we de hor float voor horizontale beweging aan de input van de horizontale keys (A D etc)
        vert = Input.GetAxis("Vertical"); // Hier koppelen we de hor float voor horizontale beweging aan de input van de horizontale keys (W S etc)
        lopen.x = hor; //Hier koppelen we de X as van de vector 3 aan de hor float waardoor het nieuwe informatie kan ontvangen van de hor float
        lopen.z = vert; //Hier koppelen we de Z as van de vector 3 aan de vert float

        transform.Translate(lopen * speed * Time.deltaTime);
        //Hiermee verplaatsen we het object op basis van de vector 3 * de speed * Time.deltaTime

    }
    private void OnCollisionEnter(Collision infoAboutWhatIHit)
    {
        //Collision aangemaakt met n naam, Als iets collide met een object met de tag "MovingBlock" dan print hij Boem in de console
        if (infoAboutWhatIHit.gameObject.tag == "MovingBlock")
        {
            print("Boem");
        }
    }
}