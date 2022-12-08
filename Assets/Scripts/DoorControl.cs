
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{


    public class DoorControl : MonoBehaviour
    {
        [Header("Room Text")]
        [SerializeField] private Text room2;
        [SerializeField] private Text room3;
        [SerializeField] private Text room4;
        [SerializeField] private Text bonusRM;
        [SerializeField] private Text roomB;
        
        [Header("Light Source")]
        [SerializeField] private Light room2R;
        [SerializeField] private Light room2L;
        
        [Header("GameObjects")]
        [SerializeField] private GameObject roomIndicator2R;
        [SerializeField] private GameObject roomIndicator2L;
        
        [Header("Materials")]
        [SerializeField] private Material openGreen;
        [SerializeField] private Material closedRed;
        
        [Header("'Other' Scripts")]
        [SerializeField] private PlayerMovement playerMove;
        
        [Header("GameObject Arrays")]
        [SerializeField] private GameObject[] door2TurnedOnOrOff;

        [HideInInspector]
        public bool openDoor2;
        [HideInInspector]
        public bool openDoor3;
        [HideInInspector]
        public bool openDoor4;
        [HideInInspector]
        public bool openDoorB;
        [HideInInspector]
        public bool openDoorBRM;


        private void Start()
        {
            openDoor2 = false;
            openDoor3 = false;
            openDoor4 = false;
            openDoorB = false;
            openDoorBRM = false;
        }

        private void Update()
        {
            if (playerMove.coinCollected == 5)
            {
                openDoor2 = true;
            }

            if (openDoor2 == true)
            {
                Open2();
            }
            else
            {
                Close2();
            }

            if (openDoor3 == true)
            {
                Open3();
            }
            else
            {
                Close3();
            }

            if (openDoor4 == true)
            {
                Open4();
            }
            else
            {
                Close4();
            }

            if (openDoorB == true)
            {
                OpenBonusR();
            }
            else
            {
                CloseBonusR();
            }
            
            if (openDoorBRM == true)
            {
                OpenB();
            }
            else
            {
                CloseB();
            }

        }

        private void Open2() // Room 2 Will Display Opened and Be Opened.
        {
            room2.text = "Room 2: Opened".ToString();
            roomIndicator2R.GetComponent<MeshRenderer>().material = openGreen;
            roomIndicator2L.GetComponent<MeshRenderer>().material = openGreen;
            room2R.GetComponent<Light>().color = Color.green;
            room2L.GetComponent<Light>().color = Color.green;
            for (int i = 0; i < door2TurnedOnOrOff.Length; i++)
            {
                door2TurnedOnOrOff[i].GetComponent<BoxCollider>().enabled = false;
                door2TurnedOnOrOff[i].SetActive(false);
                
            }

        }
        private void Close2() // Room 2 Will Display Closed and Be Closed.
        {
            room2.text = "Room 2: Closed".ToString();
            roomIndicator2R.GetComponent<MeshRenderer>().material = closedRed;
            roomIndicator2L.GetComponent<MeshRenderer>().material = closedRed;
            room2R.GetComponent<Light>().color = Color.red;
            room2L.GetComponent<Light>().color = Color.red;
            for (int i = 0; i < door2TurnedOnOrOff.Length; i++)
            {
                door2TurnedOnOrOff[i].SetActive(true);
                door2TurnedOnOrOff[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
       
        
        private void Open3() 
        {
            room3.text = "Room 3: Opened".ToString();
        } // Room 3 Will Display Opened and Be Opened.
        private void Close3() 
        {
            room3.text = "Room 3: Closed".ToString();
        } // Room 3 Will Display Closed and Be Closed.


        private void Open4() 
        {
            room4.text = "Room 4: Opened".ToString();
        } // Room 4 Will Display Opened and Be Opened.
        private void Close4() 
        {
            room4.text = "Room 4: Closed".ToString();
        } // Room 4 Will Display Closed and Be Closed.


        private void OpenBonusR() 
        {
            bonusRM.text = "Bonus: Opened".ToString();
        } // Bonus Room Will Display Opened and Be Opened.
        private void CloseBonusR() 
        {
            bonusRM.text = "Bonus: Closed".ToString();
        } // Bonus Room Will Display Closed and Be Closed.


        private void OpenB() // Boss Room Will Display Closed and Be Closed.
        {
            roomB.text = "B Room: Opened".ToString();
        }
        private void CloseB() // Boss Room Will Display Closed and Be Closed.
        {
            roomB.text = "B Room: Closed".ToString();
        }
    }
}
