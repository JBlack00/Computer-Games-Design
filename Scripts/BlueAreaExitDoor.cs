using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the door in the blue virtual area.
/// This opens the door when the OpenDoor method is called from the OpenHexDoor script.
/// </summary>
 
public class BlueAreaExitDoor : MonoBehaviour
{
    public ExitSign exitSignScript;
    public GameObject HexDoor;
    public Animator anim;
    public bool DoorOpen;

    // Use this for initialization
    void Start ()
    {
        DoorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorAnim();
    }

    public void DoorAnim()
    {
        if (DoorOpen == true)
        {
            anim.SetBool("DoorOpen", true);//Sets bool in the animator window to true to play HexDoorOpen animation
            exitSignScript.ColourChange();//Calls the ColourChange method within the ExitSign script
        }

        if (DoorOpen == false)
        {
            anim.SetBool("DoorOpen", false);//Sets bool in the animator window to false and stops animation
        }
    }
    //This is called from the OpenHexDoor script
    public void OpenDoor()
    {
        DoorOpen = true;
    }
}
