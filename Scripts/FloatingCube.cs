using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Liminal Space
/// This script is attached to the Floating Cubes in the Virtual Area.
/// This script makes the cubes float.
/// </summary>

public class FloatingCube : MonoBehaviour
{
    public int maxSpeed;//Max speed the object will float
    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        maxSpeed = 1;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();//Calls MoveVertical method
    }

    void MoveVertical()
    {   //Movement
        transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), transform.position.z);
        //Moves up and down
        if (transform.position.y > 1.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < -1.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
