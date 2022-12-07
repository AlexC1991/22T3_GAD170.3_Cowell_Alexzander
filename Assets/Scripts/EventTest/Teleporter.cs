using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AlexzanderCowell
{


    public class Teleporter : MonoBehaviour
    {
        // This cube will TELEPORT when the on teleport event "activated" is announced!.
        // TELEPORT will move the cube to a random position on the Y axis


        private void OnEnable()
        {
            Events.OnTeleporterEvent += Activate;
        }
        private void OnDisable()
        {
            Events.OnTeleporterEvent -= Activate;
        }
        private void Activate()
        {
            transform.position = new Vector3(-2, Random.Range(0.5f, 4f), 0);
        }



       
    }
}
