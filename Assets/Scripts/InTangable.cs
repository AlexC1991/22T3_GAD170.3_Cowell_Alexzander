using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Alexzander Cowell
{
public class InTangable : MonoBehaviour
 {
    [Header("GameObjects for the blockArray")]
    [SerializeField] private GameObject[] blockArray; // Holds the gameObjects for the block array which will be used for turning inTangleble and tangleble.

    [Header("Materials")]
    [SerializeField] private Material inTangleble; // Material to turn objects invisble.
    [SerializeField] private Material tangleble; // Material to turn objects into wooden blocks.

    [HideInInspector]
    public bool playerIsClose = false; // Checks if the player is close or not. Hidden in the inspector so it does not clog up the Inspector but to be accessed by other scripts.

    [HideInInspector]
    public float timer = 45; // Timer float start time.
    private float finishedTimer = 0; // Timer float finished time.
    private float holdValue; // Holds the float value of the Timer.

    [HideInInspector]
    public bool timerSS = false; // Sets the timerSS to false to start with. Hidden in the inspector so it does not clog up the Inspector but to be accessed by other scripts.

    [HideInInspector]
    public bool timeWolf = false; // Sets the timeWolf to false to start with. Hidden in the inspector so it does not clog up the Inspector but to be accessed by other scripts.


    private void Start()
    {
        holdValue = timer; // Hold value will equal the timer value so the timer can be reset back later.
        UpdatedColor1(); // Starts the Updated color method which is invisible.
    }
    private void OnTriggerEnter(Collider other) // Checks for anything entering into the trigger zone.
    {
        if (other.CompareTag("Player")) // If anything with the "Player" tag comes into the trigger zone it will activate the code below.
        {
            playerIsClose = true; // If the player is in the trigger zone it will have player is close to true.
            Debug.Log("Entered"); // Display in the Debug.Log that the "Player" has entered.
        }
    }

    private void OnTriggerExit(Collider other) // Checks for anything exiting out of the trigger zone.
    {
        if (other.CompareTag("Player")) // If anything with the "Player" tag comes out of the trigger zone it will activate the code below.
        {
            playerIsClose = false; // If the player is out of the trigger zone it will have player is close to false.
            Debug.Log("Exited"); // Display in the Debug.Log that the "Player" has Exited.
        }
    }

    private void ButtonPress() // Starts the Button Pressed Method and code underneth.
    {
        if (Input.GetKey(KeyCode.E)) // IF 'E' is pressed on the key board than timeWold will be true and Updated color2 method will start.
        {
            timeWolf = true;
            UpdatedColor2();
        }
    }

    void FixedUpdate() // Everything is checked on a Fixed update so its slower than normal update to every frame. 
    {
        if (playerIsClose == true) // If closer is close which is defined above with the trigger zones than it will alow the button to be pressed which is defined above.
        {
            ButtonPress();
        }
        for (int i = 0; i < blockArray.Length; i++) // Checks every element in the array using .Length with i assigned with all elements in the array.
        {
            if (blockArray[i].GetComponent<BoxCollider>().enabled == true) // If every block in the box collider is enabled than it will start he timer using - 1 times fixed deltaTime and set the timerSS to true.
            {
                timer -= (1) * Time.fixedDeltaTime;
                timerSS = true;
            }
        }
        if (timer <= finishedTimer) // If the timer equals or is less than the finished timer float value than it will set both timerSS and timeWold to false.
        {
            timerSS = false;
            timeWolf = false;
        }
        if (timerSS == false) // If timerSS is false than it will start the code below.
        {
            timer = holdValue; // Sets timer back to the original hold float value.
            UpdatedColor1(); // Starts the method to turn them back invisible.
        }
    }

    private void UpdatedColor1() { // Updated Color 1 method is called and starts the code below.

        for (int i = 0; i < blockArray.Length; i++) { // Checks every element in the array using .Length with i assigned with all elements in the array.
            blockArray[i].GetComponent<BoxCollider>().enabled = false; // Sets the blocks in the array to have the box collider to false so it's not solid.
            blockArray[i].GetComponent<MeshRenderer>().material = inTangleble; // Sets the blocks in the array to have the invisable materal applied to them.
        }
    }

    private void UpdatedColor2() // Updated Color 2 method is called and starts the code below.
    {
        for (int i = 0; i < blockArray.Length; i++) // Checks every element in the array using .Length with i assigned with all elements in the array.
        {
            blockArray[i].GetComponent<MeshRenderer>().material = tangleble; // Sets the blocks in the array to have the box collider to rue so it is solid.
            blockArray[i].GetComponent<BoxCollider>().enabled = true; // Sets the blocks in the array to have the wooden materal applied to them.               
        }
    }
 }
}
