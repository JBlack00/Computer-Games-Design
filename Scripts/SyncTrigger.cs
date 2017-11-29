using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the triggers in the clinical rooms.
/// This increases the syncValue and increases the SyncBar UI slider on collision by calling the Sync method within the SyncBar script.
/// </summary>

public class SyncTrigger : MonoBehaviour
{
    public SyncBar syncBarScript;
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
            syncBarScript.Sync();//Calls the Syn method within the SyncBar script
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            TriggerNotCollided();
            Destroy(this.gameObject);//Deletes trigger once it has been collided with
        }
    }
}
