using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AlexzanderCowell
{


    public class ChangeCamera : MonoBehaviour
    {
        [SerializeField] GameObject ThirdCam;
        [SerializeField] GameObject FirstCam;
        private int cameraSelection;
        private bool pressed;

        private void Start()
        {
            cameraSelection = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                pressed = true;    
            }
            else pressed = false;

            if ( pressed == true)
            {
                if (cameraSelection <= 0)
                {
                    FirstPerson();                   
                }

                if (cameraSelection > 1)
                {
                    ThirdPerson();
                    cameraSelection -= (1);
                }
                cameraSelection += (1);
            }

        } 
        private void ThirdPerson()
        {          
           ThirdCam.SetActive(true);
           FirstCam.SetActive(false);
            SelectionDown();
            Debug.Log(cameraSelection);
        }

        private void FirstPerson()
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
            Debug.Log(cameraSelection);
        }
        private void SelectionDown()
        {
            cameraSelection = 1;
            
        }
    }
}
