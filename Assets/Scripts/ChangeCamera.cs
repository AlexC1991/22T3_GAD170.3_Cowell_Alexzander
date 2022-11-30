using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace AlexzanderCowell
{


    public class ChangeCamera : MonoBehaviour
    {
        [SerializeField] GameObject ThirdCam;
        [SerializeField] GameObject FirstCam;
        private bool cameraSelection;
        private bool pressed;

        private void Start()
        {
            cameraSelection = true;
        }

        private void Update()
        {
            if (cameraSelection == true)
            {
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
            }

            else
            {
                ThirdCam.SetActive(false);
                FirstCam.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                StartChange();
                Debug.Log(cameraSelection);
            }
               
        }

        private void StartChange()
        {
            if (cameraSelection == true)
            {
                cameraSelection = false;
            }

            else cameraSelection = true;
        }

        

        
    }
}
