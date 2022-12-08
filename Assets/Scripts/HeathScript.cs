using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{
    public class HeathScript : MonoBehaviour
    {
        [SerializeField] Text healthText;

        private void Awake(){

            healthText = GetComponent<Text>();
            
        }


        private void OnEnable()
        {
            WaterTrigger._HealthUpdateEvent += UpdateHealth;
            EnemyAI._HealthUpdateEventwithEnemy += UpdateHealth;
        }

        private void OnDisable()
        {
            WaterTrigger._HealthUpdateEvent -= UpdateHealth;
            EnemyAI._HealthUpdateEventwithEnemy -= UpdateHealth;
        }
        void UpdateHealth(int value)
        {

            healthText.text = "Health: " + value.ToString();
        }
    }
   
    
}
