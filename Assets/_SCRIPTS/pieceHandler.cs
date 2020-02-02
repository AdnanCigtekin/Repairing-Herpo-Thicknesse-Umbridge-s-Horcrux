using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceHandler : MonoBehaviour
{

    public Vector3 startPosition;

    private void Awake()
    {
        //Randomize starting position after save
        startPosition = transform.position;
        float randX = Random.Range(-6, 6);
        float randZ = Random.Range(-6, 6);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkValidity()
    {
        if(Vector3.Distance(transform.position, startPosition) < 1f)
        {
            float curRotY = transform.rotation.y;
            Debug.Log("cur rot y : " + curRotY);
            if(curRotY < 30 && curRotY > -30)
            {
                Debug.Log("OBJ OK!");
                return true;
            }
        }
        return false;
    }
}
