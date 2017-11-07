using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the pillar button in Clinical Room 1.
/// This script plays an animation of the button being pressed.
/// </summary>

public class PillarButton : MonoBehaviour
{
    public Portal portalScript;
    public Animator anim; //Accesses the Animator
    public bool ButtonPressed;

    // Use this for initialization
    void Start()
    {
        ButtonPressed = false;
    }

    public void ButtonDown()
    {   
        ButtonPressed = true;

        if (ButtonPressed == true)
        {
            anim.Play("ButtonPressed"); //Plays animation
            portalScript.Portal1(); //Calls Portal1 method within the Portal script
        }     
    }
}