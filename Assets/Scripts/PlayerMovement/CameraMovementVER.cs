using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementVER : MonoBehaviour
{

    void Update()
    {
        Vector3 curEuler = transform.eulerAngles; //Dit pakt de huidige Euler-rotatie op van het GameObject
                                                  //Daarna slaat het die informatie op in een Vector3 genaamd curEuler
        curEuler.x -= Input.GetAxis("Mouse Y"); // Hiermee koppel je de X as van de vector 3 aan de input van de verticale muis beweging
        curEuler.x = ClampAngle(curEuler.x, -90, 90); //Hiermee beperk (Clamp) je de verticale rotatie tussen 90 en -90 graden
        transform.eulerAngles = curEuler; //Deze regel past de opgeslagen informatie/rotatie uit de vector 3 toe op de transform.eulerangles
                                          // Waardoor hij roteert                                         
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (min < 0 && max > 0 && (angle > max || angle < min))
        {
            angle -= 360;
            if (angle > max || angle < min)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max)))
                {
                    return min;
                }
                else
                {
                    return max;
                }
            }
        }
        else if (min > 0 && (angle > max || angle < min))
        {
            angle += 360;
            if (angle > max || angle < min)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, min)) < Mathf.Abs(Mathf.DeltaAngle(angle, max)))
                {
                    return min;
                }
                else
                {
                    return max;
                }
            }
        }

        if (angle < min)
        {
            return min;
        }
        else if (angle > max)
        {
            return max;
        }
        else
        {
            return angle;
        }
    }
}
