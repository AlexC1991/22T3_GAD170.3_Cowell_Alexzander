using AlexzanderCowell;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace AlexzanderCowell
{
    public class WaterTrigger : MonoBehaviour
    {
        [HideInInspector]
        public bool waterHit = false; // Will set if the water is hit to false until it turns true later.

        public static event Action<int> _HealthUpdateEvent; // Sends out a event for the health to update.
       
        [HideInInspector]
        public int health; // Sets a health int.

        private void Awake()
        {
            health = 15; // health int is set to 15 in the Awake method before it's called.
        }

        //private void GainHealth() // 
        //{
        //    health = Mathf.Clamp(health + 1, 0, 15);
        //    if (_HealthUpdateEvent != null)
        //    {
        //        _HealthUpdateEvent(health);
        //    }
        //}        // This is a Gain health piece of code that i have no reason to use yet but came with the helpful tutorial for using events for health.

        private void OnTriggerExit(Collider other) // Checks for anything exiting out of the trigger zone.
        {
            if (other.CompareTag("Player")) // If anything with the "Player" tag comes out of the trigger zone it will activate the code below.
            {
                //GainHealth(); // Blocked out the gainHealth method so it can not be used yet.
                waterHit = false; // turns the water hit bool to be false.                
            }
        }

        private void OnTriggerEnter(Collider other) // Checks for anything entering into the trigger zone.
        {
            if (other.CompareTag("Player")){ // If anything with the "Player" tag comes out of the trigger zone it will activate the code below.
                DecreaseHealth(); // Starts the Decrease health method below.
                waterHit = true; // Says water hit will be true.
                
            }
        }
        private void DecreaseHealth() // Decrease health method started below.
        {
            health = Mathf.Clamp(health - 1, 0, 15); // Gets the health int and uses the MathF to decrease the health of the player in the UI. Will decrease the health set in the script by -1 but will have a min value of 0 and the highest be 15.

            if (_HealthUpdateEvent != null) // If the method above starts than will ask the HealthUpdate Event if it does not equal nothing and if it does not than will send out the health calculations for the event to be picked up.
            {
                _HealthUpdateEvent(health); // Calls out the event to use the health value.
            }
        }

        private void Update(){ // Checks every frame that if the health is ever equal to 0 than the game will reload the scene using scene manager.
            if (health == 0){
                SceneManager.LoadScene(sceneName: "GrassPlains");
            }
        }
     
    }
}
