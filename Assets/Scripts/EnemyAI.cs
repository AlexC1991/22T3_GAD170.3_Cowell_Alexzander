

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace AlexzanderCowell{



    public class EnemyAI : MonoBehaviour{
        [SerializeField] GameObject player;
        [SerializeField] private float enemyMovement = 6f;
        [SerializeField] private float enemyRunSpeed = 10f;
        [SerializeField] private float enemyHealth = 20f;
        NavMeshAgent newNav;
        [SerializeField] private Transform changePos1;
        [SerializeField] private Transform changePos2;
        [SerializeField] private Transform changePos3;
        [SerializeField] private Transform changePos4;
        [Range(1,200)]
        [SerializeField] private int timer = 50;
        private Transform completePos;
        private int point1 = 1;
        private int point2 = 2;
        private int point3 = 3;
        private int point4 = 4;
        private bool finishedTimer = false;
        private int finishTime = 0;
        private int timePassage;
        private int randomOutcome;
        private float timeDelta;
        private int convertedTime;
        
        private void Awake()
        {
            newNav = GetComponent<NavMeshAgent>();
            timePassage = timer;
        }

        private void Start()
        {
            for (int i = 0; i < timePassage; i++)
            {
                startTimer();
            }
        }
            
        
        private void FixedUpdate(){

           float time = 1 * Time.fixedDeltaTime;

            randomOutcome = Random.Range(1, 4);

            if (randomOutcome == 1)
            {
                randomOutcome = point1;
            }
            else if (randomOutcome == 2)
            {
                randomOutcome = point2;
            }
            else if (randomOutcome == 3)
            {
                randomOutcome = point3;
            }
            else if (randomOutcome == 4)
            {
                randomOutcome = point4;
            }
            
            if (finishedTimer == true)
            {
                if(randomOutcome == point2)
                {
                    newNav.destination = changePos2.position;
                    startTimer();
                }
                else if (randomOutcome == point3)
                {
                    newNav.destination = changePos3.position;
                    startTimer();
                }
                else if (randomOutcome == point4)
                {
                    newNav.destination = changePos4.position;
                    startTimer();
                }
                else if (randomOutcome == point1)
                {
                    newNav.destination = changePos1.position;
                    startTimer();
                }
            }            
        }

        private void startTimer()
        {
            timer -= (1);
            if (timer == finishTime)
            {
                timer = timePassage;
                finishedTimer = true;
            }
            
        }
    }

    
}
