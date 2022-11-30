using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InTangable : MonoBehaviour
{
    [SerializeField] private GameObject blockColor;
    [SerializeField] private Material inTangleble;
    [SerializeField] private Material tangleble;

    private void Start()
    {
        blockColor.GetComponent<MeshRenderer>().material = tangleble;
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.E))
        {
            
            ChangeColor1();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            ChangeColor2();
        }
    }

    private void ChangeColor1()
    {
        if (blockColor.GetComponent<MeshRenderer>().material = inTangleble);
        {
            
            blockColor.GetComponent<MeshRenderer>().material = tangleble;
        }
    }

    private void ChangeColor2()
    {
        if (blockColor.GetComponent<MeshRenderer>().material = tangleble)
        {

            blockColor.GetComponent<MeshRenderer>().material = inTangleble; 
        }
    }
}
