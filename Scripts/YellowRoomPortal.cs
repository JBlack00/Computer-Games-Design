using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the portal in the final room of the yellow area.
/// This script allows the player to use the portal to transport to a different position.
/// </summary>

public class YellowRoomPortal : MonoBehaviour
{
    public PlayerHealth playerHealthScript;
    public GameObject portalYellowRoom;
    public GameObject teleporter;
    public GameObject Player;
    public int fadeTimer;
    private bool TransportPlayer;
    private bool teleport;
 
    // Use this for initialization
    void Start()
    {
        //Finds the player when scene loads (this assigns the player in the inspector automatically on load 
        //Needed because we dont use player prefab - we use same game object with Don't Destroy On Load
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = Player.GetComponent<PlayerHealth>();
        teleporter.SetActive(true); //Activates the portal particle system
        fadeTimer = 0;
        TransportPlayer = false;
        teleport = true;
    }

    private void LoadVirtualAreaRoom3()
    {
        playerHealthScript.LoadVirtualRoom3();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            fadeTimer = 0;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            fadeTimer++;

            if (fadeTimer >= 10)
            {
                TransportPlayer = true;

                if (TransportPlayer == true && teleport == true)
                {
                    LoadVirtualAreaRoom3();
                }
            }
        }
    }
}