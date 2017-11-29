using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the spawner on the turret.
/// This spawns the bullet and then moves its position forward using velocity.
/// </summary>

public class Turret2 : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public Rigidbody bulletPrefab;
    public Transform Bullet;
    public int timer;

    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    public void Shoot()
    {
        timer++;

        if (timer == 20)
        {
            Rigidbody hitPlayer;
            hitPlayer = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody;
            hitPlayer.velocity = transform.TransformDirection(Vector3.up * 50);
            timer = 0;
        }
    }
}

