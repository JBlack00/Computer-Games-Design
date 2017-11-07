using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the Virtual Pillars in the Virtual Area.
/// This script animates the pillars (moving them down slowly then slamming up quickly)
/// </summary>

public class VirtualPillarAnim : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private float minPos;
    private float maxPos;
    private float units = 8.0f;//Distance the object moves
    public float timer;

    void Start()
    {   //Sets the current position to the max pos on the y axis and min to current minus units
        maxPos = transform.position.y;
        minPos = transform.position.y - units;
        direction = Vector3.down;//Sets first direction
        timer = 0;
    }
 
     void Update()
     {
        //Change speed depending on direction the object is moving
        //Speed when moving up
        if(direction == Vector3.up)
        {
            speed = 15.0f;
        }
        //Speed when moving down
        else if(direction == Vector3.down)
        {
            speed = 2.0f;
        }

        //Moves the direction
        transform.Translate(direction * speed * Time.deltaTime);
         
        //Changes direction if object has reached min pos
        if(transform.position.y <= minPos)
        {
            FreezeMovement();
        }
        //Changes direction if object has reached max pos
        if (transform.position.y >= maxPos)
        {
            timer = 0.0f;
            direction = Vector3.down;
        }
     }
    //Adds a delay before moving the pillar up
    public void FreezeMovement()
    {
        timer++;

        if (timer == 200)
        {
            direction = Vector3.up;
            timer = 0.0f;
        }
    }
 }