
using UnityEngine;

namespace AlexzanderCowell
{


    public class Room2 : MonoBehaviour
    {
        [HideInInspector]
        public bool room2Interact = false; // Sets room 2 interact will be false at the start.

        [Header("'Other' Scripts")]
        [SerializeField] UITutorials tutorialS; // Uses UI tutorial script in this script.

        private void OnTriggerEnter(Collider other) // Checks for anything entering into the trigger zone.
        {
            if (other.CompareTag("Player")) // If anything with the "Player" tag comes out of the trigger zone it will activate the code below.
            {
                room2Interact = true; // If the "Player" Enters into the trigger zone it will set room2Interact to true instead of false.                
            }
        }

        private void Update()
        {
            if (tutorialS.destroyGO == true) // If DestroyGo equals to true in the UI Tutorial script it will than destroy the game object this script is attatched to.
            {
                Destroy(gameObject);
                
            }
            else
            {
                
            }
        }
    }
}
