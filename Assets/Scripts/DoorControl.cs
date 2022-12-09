
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{


    public class DoorControl : MonoBehaviour
    {
        [Header("Room Text")]
        [SerializeField] private Text room2; // Text for room 2 door.
        [SerializeField] private Text room3; // Text for room 3 door.
        [SerializeField] private Text room4; // Text for room 4 door.
        [SerializeField] private Text bonusRM; // Text for the bonus room door.
        [SerializeField] private Text roomB; // Text for the boss room door.

        [Header("Light Source")]
        [SerializeField] private Light room2R; // Light Source for room 2, this is the right light.
        [SerializeField] private Light room2L; // Light Source for room 2, this is the left light.

        [Header("GameObjects")]
        [SerializeField] private GameObject roomIndicator2R; // Object used as the ball indicator of color, This is the right one for room 2.
        [SerializeField] private GameObject roomIndicator2L; // Object used as the ball indicator of color, This is the left one for room 2.

        [Header("Materials")]
        [SerializeField] private Material openGreen; // This is the material used for open color for the door gameObject from above.
        [SerializeField] private Material closedRed; // This is the material used for closed color for the door gameObject from above.

        [Header("'Other' Scripts")]
        [SerializeField] private PlayerMovement playerMove; // Script from PlayerMovement, Used to access some variables.
        
        [Header("GameObject Arrays")]
        [SerializeField] private GameObject[] door2TurnedOnOrOff; //  This will hold the "electric barriers" for which the player can not get past.

        [HideInInspector]
        public bool openDoor2; // This is responsible for allowing door 2 to open or to close. Hides in inspector so it does not clog up the inspector but needs to be public for another script.
        [HideInInspector]
        public bool openDoor3; // This is responsible for allowing door 3 to open or to close. Hides in inspector so it does not clog up the inspector but needs to be public for another script.
        [HideInInspector]
        public bool openDoor4; // This is responsible for allowing door 4 to open or to close. Hides in inspector so it does not clog up the inspector but needs to be public for another script.
        [HideInInspector]
        public bool openDoorB; // This is responsible for allowing the bonus room to open or to close. Hides in inspector so it does not clog up the inspector but needs to be public for another script.
        [HideInInspector]
        public bool openDoorBRM; // This is responsible for allowing the boss room to open or to close. Hides in inspector so it does not clog up the inspector but needs to be public for another script.


        private void Start() // At the start of the game it will have all doors locked and closed.
        {
            openDoor2 = false; // Door 2 will be closed and locked.
            openDoor3 = false; // Door 3 will be closed and locked.
            openDoor4 = false; // Door 4 will be closed and locked.
            openDoorB = false; // Bonus room will be closed and locked.
            openDoorBRM = false; // The Boss room will be closed and locked. However is turned off in game for demo purposes currently.
        }

        private void Update() // Checks every frame for everything below.
        {
            if (playerMove.coinCollected == 5) // Checks if the player hits a coin and if the total is equal to 5.
            {
                openDoor2 = true; // If the players coin total is 5 than room 2 will open.
            }

            if (openDoor2 == true) // If door 2 is true than it starts it's method.
            {
                Open2();
            }
            else
            {
                Close2(); // If not true than it remains closed.
            }

            if (openDoor3 == true) // If door 3 is true than it starts it's method.
            {
                Open3();
            }
            else
            {
                Close3(); // If not true than it remains closed.
            }

            if (openDoor4 == true) // If door 4 is true than it starts it's method.
            {
                Open4();
            }
            else
            {
                Close4(); // If not true than it remains closed.
            }

            if (openDoorB == true) // If the bonus room door is true than it starts it's method.
            {
                OpenBonusR();
            }
            else
            {
                CloseBonusR(); // If not true than it remains closed.
            }
            
            if (openDoorBRM == true) // If the boss room door is true than it starts it's method.
            {
                OpenB();
            }
            else
            {
                CloseB(); // If not true than it remains closed.
            }

        }

        private void Open2() // Starts room 2's open code.
        {
            room2.text = "Room 2: Opened".ToString(); // Displays the door is opened to room 2.
            roomIndicator2R.GetComponent<MeshRenderer>().material = openGreen; // changes the door indicator on the right from red to green on the game object.
            roomIndicator2L.GetComponent<MeshRenderer>().material = openGreen; // changes the door indicator on the left from red to green on the game object.
            room2R.GetComponent<Light>().color = Color.green; // Displays the light color green instead of red on the right side for the game object.
            room2L.GetComponent<Light>().color = Color.green; // Displays the light color green instead of red on the left side for the game object.
            for (int i = 0; i < door2TurnedOnOrOff.Length; i++) // Gets all the objects in the array to change by using .Length against i in every instance or element in the array.
            {
                door2TurnedOnOrOff[i].GetComponent<BoxCollider>().enabled = false; // turns off the box collider so players can walk through it.
                door2TurnedOnOrOff[i].SetActive(false); // turns off the game object entirelly so it can allow the player through.
                
            }

        }
        private void Close2() // Starts room 2's closed code.
        {
            room2.text = "Room 2: Closed".ToString(); // Displays the door is closed to room 2.
            roomIndicator2R.GetComponent<MeshRenderer>().material = closedRed; // changes the door indicator on the right from green to red on the game object.
            roomIndicator2L.GetComponent<MeshRenderer>().material = closedRed; // changes the door indicator on the left from green to red on the game object.
            room2R.GetComponent<Light>().color = Color.red; // Displays the light color red instead of green on the right side for the game object.
            room2L.GetComponent<Light>().color = Color.red; // Displays the light color red instead of green on the left side for the game object.
            for (int i = 0; i < door2TurnedOnOrOff.Length; i++) // Gets all the objects in the array to change by using .Length against i in every instance or element in the array.
            {
                door2TurnedOnOrOff[i].SetActive(true); // turns on the game object entirelly so it can not allow the player through.
                door2TurnedOnOrOff[i].GetComponent<BoxCollider>().enabled = true; // turns on the box collider so players can walk through it.
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
