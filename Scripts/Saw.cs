using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the saws in the yellow virtual area.
/// This script makes the saws rotate.
/// </summary>

public class Saw : MonoBehaviour
{
    private float speed = 200f;//Speed that the object rotates

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
