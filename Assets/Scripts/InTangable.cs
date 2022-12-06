using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InTangable : MonoBehaviour
{
    [SerializeField] private GameObject[] blockArray;
    [SerializeField] private Material inTangleble;
    [SerializeField] private Material tangleble;
    [HideInInspector]
    public bool playerIsClose = false;
    [HideInInspector]
    public float timer = 35;
    private float finishedTimer = 0;
    private float holdValue;
    [HideInInspector]
    public bool timerSS = false;
    [HideInInspector]
    public bool timeWolf = false;


    private void Start()
    {
        holdValue = timer;
        UpdatedColor1();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            Debug.Log("Entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            Debug.Log("Exited");
        }
    }

    private void ButtonPress()
    {
        if (Input.GetKey(KeyCode.E))
        {
               timeWolf = true;
               UpdatedColor2();
        }
    }

    void FixedUpdate()
    {
        if (playerIsClose == true)
        {
            ButtonPress();
        }
        for (int i = 0; i < blockArray.Length; i++)
        {
            if (blockArray[i].GetComponent<BoxCollider>().enabled == true)
            {
                timer -= (1) * Time.fixedDeltaTime;
                timerSS = true;               
            }
        }
        if (timer <= finishedTimer)
        {
            timerSS = false;
            timeWolf = false;
        }
        if (timerSS == false)
        {
            timer = holdValue;
            UpdatedColor1();
        }
    }

    private void UpdatedColor1(){
        for (int i = 0; i < blockArray.Length; i++){
            blockArray[i].GetComponent<BoxCollider>().enabled = false;
            blockArray[i].GetComponent<MeshRenderer>().material = inTangleble;
        }
    }

    private void UpdatedColor2()
    {
        for (int i = 0; i < blockArray.Length; i++)
        {
            blockArray[i].GetComponent<MeshRenderer>().material = tangleble;
            blockArray[i].GetComponent<BoxCollider>().enabled = true;               
        }
    }
}
