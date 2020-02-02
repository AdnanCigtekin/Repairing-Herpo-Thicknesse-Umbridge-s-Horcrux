using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorFollower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    [SerializeField]
    public Transform anchor;
    // Update is called once per frame
    void Update()
    {
        transform.position = anchor.position;
    } 
}
