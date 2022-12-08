using System;
using UnityEngine;
using UnityEngine.AI;

namespace AlexzanderCowell{



    public class EnemyAI : MonoBehaviour {
        [SerializeField] private float enemyMovement = 6f;
        [SerializeField] private float enemyRunSpeed = 10f;
        [SerializeField] private float enemyHealth = 3f;
        NavMeshAgent newNav;
        [SerializeField] private Transform thePlayer;
        [SerializeField] private LayerMask whatIsPlayer, whatIsGround;
        [SerializeField] EnemyKillColor enemyKillColor;
        [SerializeField] GameObject coinModel;

        [SerializeField] private float attackRange,sightRange;
        private bool playIsInSight;
        private bool playIsInAttack;
        
        private Vector3 walkPoint;
        private bool walkPointSet;

        private Vector3 runPoint;
        private bool runPointSet;

        public static event Action<int> _HealthUpdateEventwithEnemy;
        [SerializeField] WaterTrigger waterTig;
        private void Start()
        {
            newNav = GetComponent<NavMeshAgent>();
            thePlayer = GameObject.Find("PlayerObj").transform;
        }


        private void Update()
        {
            playIsInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playIsInAttack = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playIsInAttack && !playIsInSight) PatrolYard();
            if (playIsInSight && playIsInAttack) ChasePlayer();
            if (enemyKillColor.colorIsGood == true) RunFromPlayer();
        }

        private void PatrolYard()
        {
            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet)
            {
                newNav.SetDestination(walkPoint);
            }

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        }

        private void SearchWalkPoint()
        {
            float randomZ = UnityEngine.Random.Range(-enemyMovement, enemyMovement);
            float randomX = UnityEngine.Random.Range(-enemyMovement, enemyMovement);
            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, whatIsGround))
                walkPointSet = true;
        }

        private void ChasePlayer()
        {
            newNav.SetDestination(thePlayer.position);
            transform.LookAt(thePlayer);
        }

        private void RunFromPlayer()
        {
            if (!runPointSet) RunPoint();

            if (runPointSet)
            {
                newNav.SetDestination(runPoint);
            }

            Vector3 distanceToRunPoint = transform.position - runPoint;

            if (distanceToRunPoint.magnitude < 1f)
                runPointSet = false;
        }

        private void RunPoint()
        {
            float randomZ = UnityEngine.Random.Range(-enemyRunSpeed, enemyRunSpeed);
            float randomX = UnityEngine.Random.Range(-enemyRunSpeed, enemyRunSpeed);
            runPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(runPoint, -transform.up, whatIsGround))
                runPointSet = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")){

                if (enemyKillColor.colorIsGood == true)
                {
                    TakeDamage();
                }
                else
                {
                    DecreaseHealth();
                }
            }
            
                
        }

        private void TakeDamage()
        {
            enemyHealth = Mathf.Clamp(enemyHealth - 1, 0, 3);

            if (enemyHealth <= 0)
            {
                DropCoins();
                KillEnemy();
            }
        }
        private void DropCoins()
        {
            Vector3 position = transform.position;
            GameObject coin = Instantiate(coinModel, position, Quaternion.identity);
        }

        private void KillEnemy()
        {
            Destroy(gameObject);

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }

        private void DecreaseHealth()
        {
            waterTig.health = Mathf.Clamp(waterTig.health - 1, 0, 15);

            if (_HealthUpdateEventwithEnemy != null)
            {
                _HealthUpdateEventwithEnemy(waterTig.health);
            }
        }


    }

    
}
