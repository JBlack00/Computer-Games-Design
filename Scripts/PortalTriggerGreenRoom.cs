using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the the portal in the green virtual area.
/// It loads the portal when all security bots are dead.
/// </summary>

public class PortalTriggerGreenRoom : MonoBehaviour
{
    public PlayerHealth playerHealthScript;
    public GameObject portal1;
    public GameObject teleporter;
    public GameObject Player;
    public int fadeTimer;
    private bool TransportPlayer;
    private bool teleport;

    // Use this for initialization
    void Start ()
    {
        //Finds the player when scene loads (this assigns the player in the inspector automatically on load 
        //Needed because we dont use player prefab - we use same game object with Don't Destroy On Load
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = Player.GetComponent<PlayerHealth>();
        fadeTimer = 0;
        TransportPlayer = false;
        teleport = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        FindEnemies();
	}
    public void FindEnemies()
    {
        print(GameObject.FindGameObjectsWithTag("SecurityBot").Length);
        //Activates the portal particle system when there are no enemies left
        if (GameObject.FindGameObjectsWithTag("SecurityBot").Length == 0)
        {
            teleporter.SetActive(true);
            teleport = true;
        }
    }

    private void LoadFinalRoom()
    {
        playerHealthScript.LoadVirtualRoom4();//calls the LoadVirtualRoom4 method within the PlayerHealth script
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
                    LoadFinalRoom();
                }
            }
        }
    }
}
