using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the turret trigger.
/// This script triggers the turret to shoot when the player collides with it.
/// </summary>

public class TurretTrigger : MonoBehaviour
{
    public Turret1 turret1script;
    public Turret2 turret2script;
    public GameObject spawner;
    public GameObject spawner2;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            spawner.SetActive(true);
            spawner2.SetActive(true);
            turret1script.Shoot();
            turret2script.Shoot();
        }
    }
}