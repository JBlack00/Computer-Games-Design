using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the tiles in the virtual areas.
/// This changes the colour of the tiles on collision with the players bullet.
/// </summary>
 
public class TileColourChange : MonoBehaviour
{
    private float colourChangeDelay = 0.5f;//Delay of colour change
    private float currentDelay = 0f;
    private bool colourChangeCollision = false;

    // Update is called once per frame
    void Update()
    {
        checkColourChange();//Calls checkColourChange method
    }

    private void checkColourChange()
    {
        if (colourChangeCollision)
        {
            Renderer rend = GetComponent<Renderer>();
            transform.GetComponent<Renderer>().material.color = Color.white;//Change colour to white
            rend.material.SetColor("_EmissionColor", Color.white);//Emissive colour to make it stand out

            if (Time.time > currentDelay)
            {
                transform.GetComponent<Renderer>().material.color = Color.cyan;//Change colour to cyan
                rend.material.SetColor("_EmissionColor", Color.cyan);//Emissive colour to make it stand out
                colourChangeCollision = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {   //Changes colour on collision with bullet
        if (col.gameObject.tag == "Bullet")
        {
            colourChangeCollision = true;
            currentDelay = Time.time + colourChangeDelay;
        }
    }
}