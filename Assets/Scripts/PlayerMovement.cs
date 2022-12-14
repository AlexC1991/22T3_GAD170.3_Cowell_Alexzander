using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using System.Runtime.CompilerServices;
using AlexzanderCowell;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    
    // INSTRUCTIONS
    //
    // This script must be on a gameobject that has a Character Controller component.
    // It will add that component if the object does not already have it.
    // This is done by the "[RequireComponent(typeof(CharacterController))]" statement on line 3 of this script. (See above.)
    //
    // Also, make a camera a child of this object and tilt it the way you want it to tilt.
    // The mouse will let you turn the character, and therefore, the camera along with it.

    [Header("References")]
    // This must be linked to the gameobject that has the "Character Controller" in the inspector.
    private CharacterController characterController;
    
    private bool playerIsCloser = false; // Checks if the player is close or not using a bool. - Added
    
    [HideInInspector]
    public int coinCollected;  // coinCollected is the point system in the game and is public so other scripts can access it but is hidden in the inspector so it does not clog up the inspector. - Added
    
    
    [SerializeField] private Vector3 playerTransform; // displays the Vector 3 player Transform. - Added
    
    private bool reLocate = false; // Sets a reLocated bool to false to start.

    [Header("GameObjects & Text")]
    [SerializeField] Text pointOut; // Text for the score system in the UI. - Added

    [Header("Scripts")]
    [SerializeField] WaterTrigger waterT; // Gets the Water Trigger script to use here. - Added

    
    [Header("Movement Variables")] // These variables (visible in the inspector) are for you to set up to match the right feel
    private float movementSpeed = 20f; 
    private float movementSpeed2 = 12f;
    [SerializeField] private float horizontalSpeed = 2.0f;
    [SerializeField] private float verticalSpeed = 2.0f;

    // These two are for the camera movement
    [SerializeField] private float yaw = 0.0f;
    [SerializeField] private float pitch = 0.0f;

    [Header("Jumping Variables")]
    // Determines how high the character can jump.
    [SerializeField] private float jumpHeight = 2f;

    // Customisable gravity. A "more negative" number makes the character fall faster.
    [SerializeField] private float gravity = -10f;

    // So the script knows if you can jump!
    private bool isGrounded;

    // To handle vertical movement
    private Vector3 velocity;

    private void Start()
    {
        // If the variable "characterController" is empty...
        if (characterController == null)
        {
            // ...then this searches the components on the gameobject and gets a reference to the CharacterController class
            characterController = GetComponent<CharacterController>();
        }        
    }


    private void OnTriggerEnter(Collider other) // Checks for anything entering into the trigger zone. - Added
    {
        if (other.CompareTag("Coin")) // If anything with the "Coin" tag comes into the trigger zone it will activate the code below.
        {
            coinCollected += (1); // If the gameObject with this script collides with a gameObject with a coin tag it will increase the coin Collected to a + 1 int value. - Added
            playerIsCloser = true; // If the gameObject with this script collides with a gameObject with a coin tag it will set the player is close to true. - Added
        }
    }

    private void OnTriggerExit(Collider other) // Checks for anything exiting out of the trigger zone. - Added
    {
        if (other.CompareTag("Coin")) // If anything with the "Coin" tag isn't in the trigger zone it will activate the code below. - Added
        {
            playerIsCloser = false; // If the gameObject with this script does not collide with a gameObject with a coin tag it will set the player is close to false. - Added
        }
    }

    private void Update()
    {
        pointOut.text = "Points: " + coinCollected.ToString(); // When the coinCollected updates it will display in the string of text in the UI for the points. - Added

        // These lines let the script rotate the character based on the mouse moving
        float moveMousex = +horizontalSpeed * Input.GetAxis("Mouse X");
        float moveMousey = horizontalSpeed * Input.GetAxis("Mouse X");
        yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalSpeed * Input.GetAxis("Mouse Y");

        // Get the Left/Right and Forward/Back values of the input being used (WASD, Joystick etc.)
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // Let the character jump if they are on the ground and they press the jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Rotate the character based off those mouse values we collected earlier
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        // This is stealing the data about the character being on the ground from the character controller
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // This fakes gravity!
        velocity.y += gravity * Time.deltaTime;

        // This takes the Left/Right and Forward/Back values to build a vector
        Vector3 movementVector = transform.right * xValue + transform.forward * zValue;

        // Finally, it applies that vector it just made to the character
            characterController.Move(movementVector * movementSpeed2 * Time.deltaTime + velocity * Time.deltaTime);

        if (waterT.waterHit == true){ // Using the Water Trigger Script and if the water hit returns true it will start the Relocate method and set reLocate to true. - Added
            StartRelocate();
            reLocate = true;
        }
    }

    private void StartRelocate() // Start if the Relocate Method.  -Added
    {
        gameObject.transform.position = playerTransform; // sets the game object transform position of this script to the player Transform.  -Added
        playerTransform = new Vector3(-19.20832f, 7.472631f, -69.0894f); // Player transform will go to a new vector 3 of that area in room 2 which is the start entry away from the water. -Added
    }



}
