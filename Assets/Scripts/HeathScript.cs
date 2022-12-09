using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{
    public class HeathScript : MonoBehaviour
    {
        [Header("Text")]
        [SerializeField] Text healthText; // Uses the health text in the UI.

        private void Awake(){ // Starts before the game starts

            healthText = GetComponent<Text>(); // Gets the component of text from the inspector.            
        }
        private void OnEnable()
        {
            WaterTrigger._HealthUpdateEvent += UpdateHealth; // Checks if the event from WaterTrigger script which is called HealthUpdateEvent starts & starts the function called UpdateHealth.
            EnemyAI._HealthUpdateEventwithEnemy += UpdateHealth; // Checks if the event from the Enemy AI script which is called HealthUpdateEventwithEnemy starts & starts the function called UpdateHealth.
        }

        private void OnDisable()
        {
            WaterTrigger._HealthUpdateEvent -= UpdateHealth; // Checks if the event from WaterTrigger script which is called HealthUpdateEvent finishes & stops the function from being used.
            EnemyAI._HealthUpdateEventwithEnemy -= UpdateHealth; // Checks if the event from the Enemy AI script which is called HealthUpdateEventwithEnemy finishes. & stops the function from being used.
        }
        void UpdateHealth(int value) // Updates the health of the health text UI element and gets the int value from the event from the other 2 scripts.
        {
            healthText.text = "Health: " + value.ToString(); // Updates the string in the UI from the 2 events in the scripts.
        }
    }
   
    
}
