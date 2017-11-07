using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the portal in Clinical Room 3.
/// This script allows the player to use the portal to transport to a the virtual area.
/// </summary>

public class Room3Portal : MonoBehaviour
{
    public PortalTriggerRoom3 portalTriggerRoom3;
    public Transform spawner;
    public GameObject portalRoom3;
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

            if (portalTimer == 1)
            {
                teleporter.SetActive(true); //Activates the portal particle system
                teleport = true;
            }
        }
    }

    //Called from the PressurePlate script
    public void Portal3()
    {
        if (portalTriggerRoom3.PlayerCollided.Equals(true)) //Checks if the bool PlayerCollided within the PortalTriggerRoom3 script is true
        {
            startTimer = true;
        }
    }

    public void LoadVirtualArea()
    {
        SceneManager.LoadScene("VirtualRoom1");//Loads VirtualRoom1 scene
        Player.transform.position = new Vector3(-43.44f, 2.039f, -45.05001f);//The pos the player will start at in the Virtual Area
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            TransportPlayer = true;

            if (TransportPlayer == true && teleport == true)
            {
                LoadVirtualArea();
            }
        }
    }
}
