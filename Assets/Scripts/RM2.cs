
using UnityEngine;

namespace AlexzanderCowell
{


    public class RM2 : MonoBehaviour
    {
        [HideInInspector]
        public bool room2Interact = false;

        [Header("'Other' Scripts")]
        [SerializeField] UITutorials tutorialS;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                room2Interact = true;                
            }
        }

        private void Update()
        {
            if (tutorialS.destroyGO == true)
            {
                Destroy(gameObject);
                
            }
            else
            {
                
            }
        }
    }
}
