using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to a blank object in the virtual areas.
/// The blank obj activates when the player survives all waves so that this script can run only at that point.
/// </summary>

public class OpenHexDoor : MonoBehaviour
{
    public BlueAreaExitDoor exitDoorScript;
    public AudioClip doorOpen;
    AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {   //Plays audio clip
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = doorOpen;
        audioSource.Play();
        exitDoorScript.OpenDoor();//Calls the OpenDoor method within the BlueAreaExitDoor script
    }
}
