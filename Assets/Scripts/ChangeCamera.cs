using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace AlexzanderCowell
{


    public class ChangeCamera : MonoBehaviour
    {
        [Header("Cameras")]
        [SerializeField] GameObject thirdCam; // Third person camera in the game.
        [SerializeField] GameObject firstCam; // First person camera in the game.

        private bool cameraSelection; // Makes sure that when one camera is selected only 1 other can be reslected by the same key.
        private bool pressed; // Indicates if the button that is used for camera is pressed or not.

        private void Start()
        {
            cameraSelection = true; // Starting the game the 3rd person camera is activated.
            
        }

        private void Update()
        {
            if (cameraSelection == true) 
            {
                thirdCam.SetActive(true); // Turns on 3rd person camera
                firstCam.SetActive(false); // Turns off 1st person camera
                firstCam.GetComponent<AudioListener>().enabled = false; // Sets the first person camera's audio listener to off.
                thirdCam.GetComponent<AudioListener>().enabled = true; // Sets the Third person camera's audio listener to on.
            } // Enables the 3rd person camera to be activated and to only have 1 audo listener in the scene at a time.

            else
            {
                thirdCam.SetActive(false); // Turns off 3rd person camera.
                firstCam.SetActive(true); // Turns on 1st person camera
                thirdCam.GetComponent<AudioListener>().enabled = false; // Sets the first person camera's audio listener to on.
                firstCam.GetComponent<AudioListener>().enabled = true; // Sets the Third person camera's audio listener to off.
            }

            if (Input.GetKeyDown(KeyCode.C)) // Pressing C will start the method below.
            {
                StartChange();               
            }
               
        }

        private void StartChange() // Pressing C Activates this method as said above.
        {
            if (cameraSelection == true) // Sets if the camera selection is already true to set it false instead which will enable the other camera.
            {
                cameraSelection = false; // Having it set to false will enable the first person view.
            }

            else cameraSelection = true; // If its already false it will enable it to be true instead which will switch it to 3rd person view.
        }

        

        
    }
}
