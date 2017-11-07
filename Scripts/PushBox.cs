using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the player.
/// This script allows the player to push the box this script is attached to.
/// The box will be pushed using the specified force and only in the direction specified (this stops the player pushing the box into a corner and being unable to move it).
/// </summary>

public class PushBox : MonoBehaviour
{
    public float pushForce = 2.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        //Check whether rigidbody is either non-existant or kinematic
        if (body == null || body.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.1f)
        {
            return;
        }

        //Push direction for object
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, hit.moveDirection.z);

        //Apply push force to object
        body.velocity = pushForce * pushDirection;
    }
}