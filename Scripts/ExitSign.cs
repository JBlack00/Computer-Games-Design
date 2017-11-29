using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the exit door sign in the virtual areas.
/// The sign changes colour when ColourChange is called.
/// ColourChange is called from the BlueAreaDoor script when the player survives all waves.
/// </summary>

public class ExitSign : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {   //This is the starting colour of the exit sign
        Renderer rend = GetComponent<Renderer>();
        transform.GetComponent<Renderer>().material.color = Color.red;//Standard colour
        rend.material.SetColor("_EmissionColor", Color.red);//Emissive colour to make it stand out
    }
    //This is called from BlueAreaExitDoor script
    public void ColourChange()
    {   //This will change the colour of the sign to green
        Renderer rend = GetComponent<Renderer>();
        transform.GetComponent<Renderer>().material.color = Color.green;//Standard colour
        rend.material.SetColor("_EmissionColor", Color.green);//Emissive colour to make it stand out
    }
}
