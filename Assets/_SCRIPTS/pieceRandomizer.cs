using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceRandomizer : MonoBehaviour
{

    [SerializeField]
    private Transform[] pieceSlots;
    private bool[] isSlotOccupied;
    [SerializeField]
    private Transform[] pieces;
    // Start is called before the first frame update
    void Start()
    {
        isSlotOccupied = new bool[pieceSlots.Length];
        for (int i = 0; i < pieces.Length; i++)
        {
            bool passed = false;
            while (!passed)
            {
                int newSlot = Random.Range(0, pieceSlots.Length);
                if (!isSlotOccupied[newSlot])
                {
                    pieces[i].position = pieceSlots[newSlot].position;
                    isSlotOccupied[newSlot] = true;
                    passed = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
