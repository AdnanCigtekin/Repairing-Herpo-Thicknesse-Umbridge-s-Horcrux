using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    [SerializeField]
    private Vector3 targetPos;
    private Transform mainCam;

    [SerializeField]
    private Transform anchorGuide;

    private void Awake()
    {
        mainCam = Camera.main.transform;
        mainCam.LookAt(targetPos);
        
    }

    public void RotateHorizontal(int direction, float speed)
    {
        transform.Rotate(0, speed * direction * Time.deltaTime * 10,0);
        anchorGuide.transform.Rotate(0, speed * direction * Time.deltaTime * 10, 0);
        mainCam.LookAt(targetPos);
    }

    public void RotateVertical(int direction, float speed)
    {
        if(mainCam.position.y + speed * direction * Time.deltaTime * 10 > 2 && mainCam.position.y + speed * direction * Time.deltaTime * 10 < 15)
        {
            transform.Rotate(speed * direction * Time.deltaTime * 10,0 , 0);

        }
        mainCam.LookAt(targetPos);

    }

}
