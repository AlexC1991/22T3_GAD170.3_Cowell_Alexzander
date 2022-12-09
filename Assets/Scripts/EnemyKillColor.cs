
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{

 public class EnemyKillColor : MonoBehaviour
 {
    [Header("GameObject")]
    [SerializeField] private GameObject enemyArray; // Gets the enemy gameObject.

    [Header("Material")]
    [SerializeField] private Material canKill; // Gets the material for when you can kill it which will be a blue material.
    [SerializeField] private Material dontKill; // Gets the material for when you can not kill it which will be a red or black material.
    [SerializeField] private Sprite sadFace; // Gets the Sprite image for when it turns blue so it changes it's face from angry to sad and scared.
    [SerializeField] private Sprite angryFace; // Gets the Sprite image for when it turns red or black so it changes it's face from sad and scared to angry.


    [HideInInspector]
    public bool closeToMe = false; // Checks if the something is close to it.
    
    [HideInInspector]
    public bool colorIsGood; // Checks if the color is good which be for when it can be killed or not.
    
    private float timer = 15; // Timer start time for when the enemy state changes.
    private float finishedTimer = 0; // Timer finished time for it to change back.
    private float holdValue; // Holding timer original time so it reverts back.
    private bool timerSS; // Checks when the timer starts.
    private bool buttonDown = false; // Checks if the button has been pressed.
    



    private void Start()
    {
        holdValue = timer; // Sets the hold value to what the timer is so it can be used later.
        CantKillColor(); // Sets the Enemy to have the color and sprite of which the player can not kill them.
        buttonDown = false; // Sets the button pressed is false.
    }
    private void OnTriggerEnter(Collider other)  // Checks if a gameObject goes into it's trigger Collider zone. Other is representive of a gameObject.
    {
        if (other.CompareTag("Player")) // If the gameObject with the "Player" tag goes into the collider zone then activate.
        {
            closeToMe = true; // Says the "Player" is in the trigger zone and has turned close to me true.
            Debug.Log("Entered"); // Debug for when i needed to know if it detected the "Player".
        }
    }

    private void OnTriggerExit(Collider other) // Checks if a gameObject leaves it's trigger Collider zone. Other is representive of a gameObject. 
    {
        if (other.CompareTag("Player")) // If the gameObject with the "Player" tag goes out of the collider zone then deactivate.
        {
            closeToMe = false; // Says the "Player" is out of the trigger zone and has turned close to me false.
            Debug.Log("Exited"); // Debug for when i needed to know if it detected the "Player" leaving the trigger zone.
        }
    }

    private void TriggerButton() // Starts the Trigger Button Code.
    {
        if (Input.GetKeyDown(KeyCode.E)) // Allows the E button to be pressed.
        {
            Debug.Log("Pressed Button"); // Checks if the E button has been pressed.
            buttonDown = true; //  Turns button down to true if the E button has been pressed.
            if (buttonDown == true) // If the button down is true it starts code.
            {
                KillColor(); // Starts the kill color method.
                timerSS = true; // Starts the timer with the timerSS equals true.
                buttonDown = false; // Makes sure that the button can be registered once so its set to false stright after being turned to true.
            }
        }
    }

    private void FixedUpdate() // Fixed Update being used for a slower frame rate.
    {
        if (closeToMe == true) // If close to me is true from the player being inside the trigger collider zone.
        {
            TriggerButton(); // Starts the function above to allow the player to press E and than start a timer & changing the state of the enemy.
        }

        if (colorIsGood == true) // If the color is good which is the kill color it will run a code.
        {
            Debug.Log("Kill"); // Puts in the debug panel the word Kill while this is activated.
            if (timerSS == true) // if the timerSS is true from the character pressing E than it will start the timer below.
            {
                timer -= (1) * Time.fixedDeltaTime; // Counts down from timer set above by -1 using a fixed delta time which is a slower timer.
            }
        }

        if (timer <= finishedTimer) // If the timer becomes the same as finished timer value or less than. The code below activates.
        {
            timerSS = false; // Timer will stop because it's no longer true as stated it will become false.
            timer = holdValue; // Timer will reset it's value by the original time set at the start of the game using holdValue.
            CantKillColor(); // Starts the cant kill method.
        }

    }

    private void KillColor() // Kill Color activtes the code below.
    {
        enemyArray.GetComponent<MeshRenderer>().material = canKill; // Changes the material of the enemy gameObject attatched to a can kill material.
        enemyArray.GetComponentInChildren<Image>().sprite = sadFace; // Changes the Sprite of the image from being angry to scared & sad.
        colorIsGood = true; // Says that the kill color is activated to to start the code above for it which is the timer to debug log the kill string.
    }

    private void CantKillColor() // Cant Kill Color activates the code below.
    {
        enemyArray.GetComponent<MeshRenderer>().material = dontKill; // Changes the material of the enemy gameObject attatched to a can not kill material.
        enemyArray.GetComponentInChildren<Image>().sprite = angryFace; // Changes the Sprite of the image from being scared & sad to angry.
        colorIsGood = false; // Says that the kill color is deactivated which stops the timer from continuing.
    }


 }
}
