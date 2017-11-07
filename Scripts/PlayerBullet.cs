using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the bullet prefab which the player shoots.
/// This script contains a list of objects that will destroy the bullet on collision.
/// </summary>

public class PlayerBullet : MonoBehaviour
{
    public int timer;

    private void Start()
    {
        timer = 0;
    }

    void Update()
    {   //**There's a problem - when the player is running he collides with the bullet in front, causing the bullet to slow down**
        //This ensures that if that happens, it will delete the bullet from the scene anyway (stopping it floating slowly)
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
        if (col.gameObject.tag == "Pillar")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "PillarButton")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Portal")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "HexLight")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Box")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "PressurePlate")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "ShrinkBox")
        {
            Destroy(this.gameObject);
        }
    }
}