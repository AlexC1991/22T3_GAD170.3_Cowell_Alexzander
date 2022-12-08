using AlexzanderCowell;
using System;

using UnityEngine;

namespace AlexzanderCowell
{
    public class WaterTrigger : MonoBehaviour
    {
        [HideInInspector]
        public bool waterHit = false;

        public static event Action<int> _HealthUpdateEvent;
        [HideInInspector]
        public int health;

        private void Awake()
        {
            health = 15;
        }

        //private void GainHealth()
        //{
        //    health = Mathf.Clamp(health + 1, 0, 15);
        //    if (_HealthUpdateEvent != null)
        //    {
        //        _HealthUpdateEvent(health);
        //    }
        //}

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //GainHealth();
                waterHit = false;               
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")){
                DecreaseHealth();
                waterHit = true;
                
            }
        }
        private void DecreaseHealth()
        {
            health = Mathf.Clamp(health - 1, 0, 15);

            if (_HealthUpdateEvent != null)
            {
                _HealthUpdateEvent(health);
            }
        }
     
    }
}
