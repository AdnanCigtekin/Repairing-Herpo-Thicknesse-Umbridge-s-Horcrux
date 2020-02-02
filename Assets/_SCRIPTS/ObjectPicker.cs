using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{

    public GameObject pickedObject = null;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 3))
        //{
        //    if(hit.transform.tag == "brokenPiece")
        //    {
        //        Debug.Log("There is a object under : " + hit.transform.name);
        //        if (Input.GetKeyDown("f") && pickedObject == null) {
        //            if(pickedObject == null)
        //            {
        //                pickUpObject(hit.transform.gameObject);
        //                return;
        //            }

        //        }

        //    }
        //}
        if (Input.GetKeyDown("f") && pickedObject == null)
        {
            
            GameObject[] pieces;
            pieces = GameObject.FindGameObjectsWithTag("brokenPiece");
            Debug.Log(pieces.Length);
            GameObject closest = null;
            float distance = 30;
            Vector3 position = transform.position;
            foreach (GameObject go in pieces)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    Debug.Log(closest);
                    closest = go;
                    distance = curDistance;
                }
            }
            if(closest != null)
            {
                Debug.Log("picked");
                pickUpObject(closest);
                return;
            }
        }




        if (Input.GetKeyDown("f") && pickedObject != null)
            dropObject();
    }

    private void dropObject()
    {
        bool result = pickedObject.GetComponent<pieceHandler>().checkValidity();

        if (result)
        {
            Destroy(pickedObject.GetComponent<FixedJoint>());
            Destroy(pickedObject.GetComponent<Rigidbody>());
            pickedObject.GetComponent<Collider>().isTrigger = false;
            pickedObject.transform.position = pickedObject.GetComponent<pieceHandler>().startPosition;
            pickedObject.transform.rotation = Quaternion.identity;
            pickedObject.tag = "repairedPiece";
            pickedObject = null;
        }
        else
        {
            Debug.Log("Object dropped");
            pickedObject.GetComponent<Collider>().isTrigger = false;
            Destroy(pickedObject.GetComponent<FixedJoint>());
            pickedObject = null;
        }

    }

    private void pickUpObject(GameObject obj) {
        Debug.Log("object picked up");
        Transform tempAnchorFollower = GetComponent<AnchorFollower>().anchor;
        tempAnchorFollower.position = new Vector3(tempAnchorFollower.position.x,
                                                   tempAnchorFollower.position.y + 3,
                                                   tempAnchorFollower.position.z);
        pickedObject = obj;
        pickedObject.GetComponent<Collider>().isTrigger = true;
        pickedObject.transform.position = new Vector3(
            transform.position.x,
            transform.position.y - 5,
            transform.position.z
            ) ;
        pickedObject.transform.rotation = Quaternion.identity;
        FixedJoint myJoint = pickedObject.AddComponent<FixedJoint>();
        myJoint.connectedBody = GetComponent<Rigidbody>();
    }
}
