using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the box that the player can push in Clinial Room 2.
/// This script stops the box moving when it collides with a collider placed on the pressure plate.
/// </summary>

public class BoxMovement : MonoBehaviour
{
    public GameObject Box;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "BoxStopCollider")
        {   //Stops box moving on collision with trigger
            Box.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}