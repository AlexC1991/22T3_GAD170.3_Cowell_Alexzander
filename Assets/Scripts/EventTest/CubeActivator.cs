using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AlexzanderCowell
{


    public class CubeActivator : MonoBehaviour
    {
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Events.OnTeleporterEvent?.Invoke();
                Events.OnColorChangerEvent?.Invoke();
            }
        }
    }
}
