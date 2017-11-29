using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the Security Bot.
/// This script allows the security bot to shoot.
/// It instantiates a bullet and then moves its position using velocity.
/// </summary>

public class SecurityBotShooting : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform Bullet;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public int timer;

    // Use this for initialization
    void Start ()
    {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shoot();
	}

    public void Shoot()
    {
        timer++;

        if(timer == 50)
        {
            Rigidbody hitPlayer;
            hitPlayer = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody;
            hitPlayer.velocity = transform.TransformDirection(Vector3.up * 50);
            timer = 0;
        }

    }
}
