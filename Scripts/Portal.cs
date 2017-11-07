using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the portal.
/// This script allows the player to use the portal to transport to a different position.
/// </summary>

public class Portal : MonoBehaviour
{
    public PillarButton pillarButtonScript;//Accesses PillarButton script
    public GameObject portal1;
    public GameObject teleporter;
    public GameObject Player;
    public int portalTimer;
    public bool startTimer;
    public bool TransportPlayer;
    public bool teleport;

    // Use this for initialization
    void Start ()
    {
        portalTimer = 0;
        TransportPlayer = false;
        teleport = false;
        startTimer = false;
    }
	
	// Update is called once per frame
	void Update ()
    {   //Causes a delay when activating the particle system to stop in instantly playing
        if (startTimer == true)
        {
            portalTimer++; //Increases timer

            if(portalTimer == 150)
            {
                teleporter.SetActive(true); //Activates the portal particle system
                teleport = true;
            }
        }
    }

    //Called from the PillarButton script
    public void Portal1()
    {
        if(pillarButtonScript.ButtonPressed.Equals(true)) //Checks if the bool ButtonPressed within the PillarButton script is true
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
                Player.transform.position = new Vector3(0f, 1.043f, 9.16f); //Transports player to new portal in ClinicalRoom2
            }
        }
    }
}