using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVert: MonoBehaviour
{
    public float sensitivity = 100.0f; // Sensitivity for mouse movement

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        Vector3 curEuler = transform.eulerAngles;
        curEuler.x -= mouseY;
        curEuler.x = ClampAngle(curEuler.x, -90, 90);
        transform.eulerAngles = curEuler;
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
