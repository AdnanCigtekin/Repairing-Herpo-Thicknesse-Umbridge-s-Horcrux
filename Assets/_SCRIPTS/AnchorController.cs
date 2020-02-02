using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorController : MonoBehaviour
{

    private float firstX = 0;
    private float firstY = 0;
    private bool arrangingHeight = false;
    [SerializeField]
    private Transform followerAnchor;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            arrangingHeight = true;
        }
        else
        {
            arrangingHeight = false;
        }


        if (Input.GetMouseButtonDown(0))
        {
            firstX = Input.mousePosition.x;
            firstY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!arrangingHeight)
            {
                if (Input.mousePosition.x > firstX)
                {
                    //motor.RotateHorizontal(1, (Input.mousePosition.x - firstX));
                    transform.Translate(Vector3.right * 10 * Time.deltaTime);
                }
                else if (Input.mousePosition.x < firstX)
                {
                    //motor.RotateHorizontal(-1, (-Input.mousePosition.x + firstX));
                    transform.Translate(Vector3.left * 10 * Time.deltaTime);
                }

                if (Input.mousePosition.y > firstY)
                {
                    //motor.RotateVertical(-1, (Input.mousePosition.y - firstY));
                    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
                }
                else if (Input.mousePosition.y < firstY)
                {
                    //motor.RotateVertical(1, (-Input.mousePosition.y + firstY));
                    transform.Translate(Vector3.back * 10 * Time.deltaTime);
                }
            }
            else
            {
                if (Input.mousePosition.x > firstX)
                {
                    //motor.rotatehorizontal(1, (ınput.mouseposition.x - firstx));
                     transform.Translate(Vector3.right * 10 * Time.deltaTime);
                    //followeranchor.transform.rotate(0, -360 * time.deltatime, 0);
                }
                else if (Input.mousePosition.x < firstX)
                {
                    //motor.rotatehorizontal(-1, (-ınput.mouseposition.x + firstx));
                    transform.Translate(Vector3.left * 10 * Time.deltaTime);
                    //followeranchor.transform.rotate(0, 360 * time.deltatime, 0);

                }



                if (Input.mousePosition.y > firstY)
                {
                    //motor.RotateVertical(-1, (Input.mousePosition.y - firstY));
                    transform.Translate(Vector3.up * 10 * Time.deltaTime);
                    
                }
                else if (Input.mousePosition.y < firstY)
                {
                    //motor.RotateVertical(1, (-Input.mousePosition.y + firstY));
                    transform.Translate(Vector3.down * 10 * Time.deltaTime);
                }
            }

            firstY = Input.mousePosition.y;
            firstX = Input.mousePosition.x;
        }
        else
        {
            firstY = Input.mousePosition.y;
            firstX = Input.mousePosition.x;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            followerAnchor.transform.Rotate(0, -360 * Time.deltaTime, 0);

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            followerAnchor.transform.Rotate(0, 360 * Time.deltaTime, 0);

        }
    }
}
