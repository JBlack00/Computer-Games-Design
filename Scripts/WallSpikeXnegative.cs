using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the spikes in the Virtual Area.
/// This script animates the spikes.
/// </summary>

public class WallSpikeXnegative : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private float min;
    private float max;
    private float distance = 7.0f;
    private float time;

    // Use this for initialization
    void Start()
    {   //Minimum and maximum values for spike movement set, initial direction of movement also set.
        min = transform.position.x;
        max = transform.position.x - distance;
        direction.Set(0, 0, -1);
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //Change speed depending on direction the object is moving.
        if (direction.z == -1)
        {
            speed = 30.0f;
        }
        else if (direction.z == 1)
        {
            speed = 2.0f;
        }
        //Moves the object.
        transform.Translate(direction * speed * Time.deltaTime);

        //Changes direction if object has reached min pos
        if (transform.position.x >= min)
        {
            FreezeMovement();
        }
        //Changes direction if object has reached max pos
        if (transform.position.x <= max)
        {
            time = 0.0f;
            direction.z = 1;
        }
    }
    //Adds a delay
    private void FreezeMovement()
    {
        time++;

        if (time == 250)
        {
            direction.z = -1;
            time = 0.0f;
        }
    }
 } 