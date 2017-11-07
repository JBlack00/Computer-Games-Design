using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the player.
/// This script allows the player to shoot.
/// It instantiates a bullet and then moves its position using velocity.
/// </summary>

public class PlayerShooting : MonoBehaviour
{
    public GameObject spawnPoint;
    public Rigidbody bulletPrefab;
    public Transform Bullet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //Shoots when left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody hitPlayer;
            hitPlayer = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody;
            hitPlayer.velocity = transform.TransformDirection(Vector3.up * 50);
        }
    }
}