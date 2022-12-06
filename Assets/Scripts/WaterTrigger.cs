using AlexzanderCowell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool waterHit = false;

    [Header("'Other' Scripts")]
    [SerializeField] UITutorials tutorialS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterHit = true;
        }
    }

    private void Update()
    {
        if (tutorialS.destroyGO == true)
        {
            
        }
        else
        {

        }
    }
}
