using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<CameraMotor>();
    }
    private CameraMotor motor;
    private float firstX = 0;
    private float firstY = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            firstX = Input.mousePosition.x;
            firstY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(1))
        {
            if(Input.mousePosition.x > firstX)
            {
                motor.RotateHorizontal(1, (Input.mousePosition.x - firstX));
            }
            else if (Input.mousePosition.x < firstX)
            {
                motor.RotateHorizontal(-1, (-Input.mousePosition.x + firstX));
            }

            if (Input.mousePosition.y > firstY)
            {
                motor.RotateVertical(-1, (Input.mousePosition.y - firstY));
            }
            else if (Input.mousePosition.y < firstY)
            {
                motor.RotateVertical(1, (-Input.mousePosition.y + firstY));
            }

            firstY = Input.mousePosition.y;
            firstX = Input.mousePosition.x;
        }else
        {
            firstY = Input.mousePosition.y;
            firstX = Input.mousePosition.x;
        }
    }
}
