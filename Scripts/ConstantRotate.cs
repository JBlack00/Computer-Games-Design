using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the cubes in the main menu.
/// This script makes the cubes rotate.
/// </summary>

public class ConstantRotate : MonoBehaviour
{
    private float speed = 20f;//Speed that the object rotates

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
