using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Alexzander Cowell
{
 
    public class Coin : MonoBehaviour
    {
       private bool playerIsClose = false; // Sets a bool depending if the player has collided with it or not.


       private void OnTriggerEnter(Collider other) // Asks if something has entered the trigger zone of the collider space. Other is represented of the gameObject this script is attatched to.
       {
          if (other.CompareTag("Player")) // Looking for anything with the tag called "Player" and if it enters the gameObjects collider space.
          {
            playerIsClose = true; //  If the "Player is in the space it will say playerIsClose to be true instead of false.
            Destroy(gameObject); // Destroys the gameObject this script is attatched to.
          }
       }
    }
}
