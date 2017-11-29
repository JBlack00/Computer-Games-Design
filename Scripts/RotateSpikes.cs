using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the spikes on the Spike Bot.
/// This script makes the spikes rotate.
/// </summary>

public class RotateSpikes : MonoBehaviour
{
    private float speed = 500f;//Speed that the object rotates

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
