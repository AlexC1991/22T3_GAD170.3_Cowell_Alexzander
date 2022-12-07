using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace AlexzanderCowell
{


    public class ColorChanger : MonoBehaviour
    {
        // This cube will change COLOR when the "activated" event is called.
        // new Color means the cube will change to a new color.

        private int Colors;
        [SerializeField] private Material reD;
        [SerializeField] private Material bluE;
        [SerializeField] private Material yelloW;
        [SerializeField] private Material whitE;
        private bool red = false;
        private bool blue = false;
        private bool yellow = false;
        private bool white = false;
        private bool equals1 = false;
        private bool equals2 = false;
        private bool equals3 = false;
        private bool equals4 = false;

        private void OnEnable()
        {
            Events.OnColorChangerEvent += Activate;
        }
        private void OnDisable()
        {
            Events.OnColorChangerEvent -= Activate;
        }
        private void Activate()
        {
            Colors = Random.Range(1, 4);
            
            if (Colors == 1)
            {
                
                equals1 = true;
            }
            if (Colors == 2)
            {
                
                equals2 = true;
            }
            if (Colors == 3)
            {
                
                equals3 = true;
            }
            if (Colors == 4)
            {
                
                equals4 = true;
            }

            if (red == false)
            {
                Change();
            }
            if (blue == false)
            {
                Change();
            }
            if (yellow == false)
            {
                Change();
            }
            if (white == false)
            {
                Change();
            }

        }

        private void ChangeRed()
        {
            if  (red == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = reD;
            }


            if (gameObject.GetComponent<MeshRenderer>().material = reD)
            {
                red = false;
                equals1 = false;
            }
        }

        private void Update()
        {            
                      
        }

        private void ChangeBlue()
        {
            if (blue == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = bluE;
            }
            
            
            if (gameObject.GetComponent<MeshRenderer>().material = bluE)
            {
                blue = false;
                equals2 = false;
            }
        }

        private void ChangeYellow()
        {
            if (yellow == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = yelloW;
            }


            if (gameObject.GetComponent<MeshRenderer>().material = yelloW)
            {
                yellow = false;
                equals3 = false;
            }
        }

        private void ChangeWhite()
        {
            if (white == true)
            {
                gameObject.GetComponent<MeshRenderer>().material = whitE;
            }


            if (gameObject.GetComponent<MeshRenderer>().material = whitE)
            {
                white = false;
                equals4 = false;
            }
        }

        private void Change()
        {
            if (equals1 == true)
            {
                ChangeRed();
                red = true;
            }
            if (equals2 == true)
            {
                ChangeBlue();
                blue = true;
            }
            if (equals3 == true)
            {
                ChangeYellow();
                yellow = true;
            }
            if (equals4 == true)
            {
                ChangeWhite();
                white = true;
            }
        }
    }

    
}
