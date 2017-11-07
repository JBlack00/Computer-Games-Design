using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the pressure plate in Clinical Room 2.
/// This script handles collision between the box and pressure plate.
/// When the box collides with the pressure plate, it calls the Portal2 method in the Room2Portal script.
/// </summary>

public class PressurePlate : MonoBehaviour
{
    public Room2Portal room2PortalScript;//Access Room2Portal script
    public GameObject Box;//Object to push onto pressure plate
    public bool BoxOnPressurePlate;

    // Use this for initialization
    void Start ()
    {
        BoxOnPressurePlate = false;
    }
    //This is called if the box collides with the pressure plate
    public void PressurePlateCollided()
    {
        BoxOnPressurePlate = true;
    }
    //This is called if the box is NOT colliding with the pressure plate
    public void PressurePlateNotCollided()
    {
        BoxOnPressurePlate = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Box")
        {
            PressurePlateCollided();//Calls this method when pressure plate and box collide
            room2PortalScript.Portal2();//Calls Portal2 method within the Room2Portal script
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Box")
        {
            PressurePlateNotCollided();//Calls this method when pressure plate and box are NOT colliding
        }
    }
}