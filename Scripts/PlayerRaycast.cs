using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the player.
/// This script allows the player to interact with objects.
/// </summary>

public class PlayerRaycast : MonoBehaviour
{
    public PillarButton pillarButtonScript;
    public GameObject Button;
    public GameObject PortalCollider;
    public float interactDistance = 2f;

    // update is called once per frame
    void Update()
    {   //creates raycast to allow the player to interact with objects hit (i.e. buttons)
        Ray ray = new Ray(transform.position, transform.forward);//Shoot raycast forward
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.blue); //Draws blue ray visible in scene view (for testing purposes)

        if (Input.GetKeyDown(KeyCode.E)) //If E button is pressed
        {
            if (Physics.Raycast(ray, out hit, interactDistance))
            {   //Press button if raycast collides with it
                if (hit.collider.gameObject.tag == "PillarButton")
                {                    
                    pillarButtonScript.ButtonDown(); //Calls the ButtonDown method within the PillarButton script
                }
            }
        }
    }
}