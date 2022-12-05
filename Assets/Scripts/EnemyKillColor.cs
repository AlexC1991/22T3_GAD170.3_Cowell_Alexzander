
using UnityEngine;


public class EnemyKillColor : MonoBehaviour
{
    [SerializeField] private GameObject enemyArray;
    [SerializeField] private Material canKill;
    [SerializeField] private Material dontKill;
    [HideInInspector]
    public bool closeToMe = false;
    private float timer = 15;
    private float finishedTimer = 0;
    private float holdValue;
    private bool timerSS;
    private bool buttonDown = false;
    private bool colorIsGood;


    private void Start()
    {
        holdValue = timer;
        CantKillColor();
        buttonDown = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            closeToMe = true;
            Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            closeToMe = false;
            Debug.Log("Exited");
        }
    }

    private void TriggerButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed Button");
            buttonDown = true;
            if (buttonDown == true)
            {
                KillColor();
                timerSS = true;
                buttonDown = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (closeToMe == true)
        {
            TriggerButton();
        }

        if (colorIsGood == true)
        {
            Debug.Log("Kill");
            if (timerSS == true)
            {
                timer -= (1) * Time.fixedDeltaTime;
            }
        }

        if (timer <= finishedTimer)
        {
            timerSS = false;
            timer = holdValue;
            CantKillColor();
        }

    }

    private void KillColor()
    {
        enemyArray.GetComponent<MeshRenderer>().material = canKill;
        colorIsGood = true;
    }

    private void CantKillColor()
    {
        enemyArray.GetComponent<MeshRenderer>().material = dontKill;
        colorIsGood = false;
    }
}
