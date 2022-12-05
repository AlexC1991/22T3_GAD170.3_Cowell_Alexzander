using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace AlexzanderCowell
{


    public class ChangeCamera : MonoBehaviour
    {
        [SerializeField] GameObject thirdCam;
        [SerializeField] GameObject firstCam;
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
                thirdCam.SetActive(true);
                firstCam.SetActive(false);
                firstCam.GetComponent<AudioListener>().enabled = false;
                thirdCam.GetComponent<AudioListener>().enabled = true;
            }

            else
            {
                thirdCam.SetActive(false);
                firstCam.SetActive(true);
                thirdCam.GetComponent<AudioListener>().enabled = false;
                firstCam.GetComponent<AudioListener>().enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                StartChange();
                
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
