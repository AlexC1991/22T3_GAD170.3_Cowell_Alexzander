using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class OnCollision : MonoBehaviour
{
    [SerializeField] Collision Pole;
    [SerializeField] Collider player;
    private bool entered = false;
   

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if (player = Pole.collider)
        {
            Debug.Log("Touched");
        }
        
              
    }
}
