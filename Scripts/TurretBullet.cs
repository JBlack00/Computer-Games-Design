using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the bullet prefab which the turret shoots.
/// This script contains a list of objects that will destroy the bullet on collision.
/// </summary>

public class TurretBullet : MonoBehaviour
{
    public int timer;

    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBullet();
    }

    public void DestroyBullet()
    {
        timer++;

        if (timer == 25)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {   //The bullet will be destroyed when it collides with objects with these tags
        if (col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Ceiling")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}