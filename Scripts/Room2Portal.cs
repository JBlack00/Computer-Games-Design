using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the portal in Clinical Room 2.
/// This script allows the player to use the portal to transport to a different position.
/// </summary>

public class Room2Portal : MonoBehaviour
{
    public PressurePlate pressurePlateScript;//Accesses the PressurePlate script
    public GameObject portalRoom2;
    public GameObject teleporter;
    public GameObject Player;
    public int portalTimer;
    public bool startTimer;
    public bool TransportPlayer;
    public bool teleport;

    // Use this for initialization
    void Start()
    {
        portalTimer = 0;
        TransportPlayer = false;
        teleport = false;
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {   //Causes a delay when activating the particle system to stop in instantly playing
        if (startTimer == true)
        {
            portalTimer++; //Increases timer

            if (portalTimer == 150)
            {
                teleporter.SetActive(true); //Activates the portal particle system
                teleport = true;
            }
        }
    }
    //Called from the PressurePlate script
    public void Portal2()
    {
        if (pressurePlateScript.BoxOnPressurePlate.Equals(true)) //Checks if the bool BoxOnPressurePlate within the PressurePlate script is true
        {
            startTimer = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            TransportPlayer = true;

            if (TransportPlayer == true && teleport == true)
            {
                Player.transform.position = new Vector3(0.05f, 1.13f, 20.851f); //Transports player to new portal in ClinicalRoom3
            }
        }
    }
}