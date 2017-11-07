using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the collider/trigger in Clinical Room 3 (behind the boxes).
/// This script handles collision between the player and the trigger.
/// When the player collides with the trigger, it calls the Portal3 method in the Room3Portal script.
/// </summary>

public class PortalTriggerRoom3 : MonoBehaviour
{
    public Room3Portal room3PortalScript;//Access Room3Portal script
    public GameObject Player;
    public bool PlayerCollided;

    // Use this for initialization
    void Start()
    {
        PlayerCollided = false;
    }
    //This is called if the player collides with the collider/trigger
    public void TriggerCollided()
    {
        PlayerCollided = true;
    }
    //This is called if the player is NOT colliding with the collider/trigger
    public void TriggerNotCollided()
    {
        PlayerCollided = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            TriggerCollided();
            room3PortalScript.Portal3();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            TriggerNotCollided();
        }
    }
}
