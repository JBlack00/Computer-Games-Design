using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the individual boxes used in the wall of boxes.
/// This script plays an animation of the box shrinking and then destoys the box.
/// </summary>

public class BoxShrink : MonoBehaviour
{
    public GameObject box;
    public int timer;
    public bool BoxHit;

    // Use this for initialization
    void Start ()
    {
        BoxHit = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BoxHit == true)
        {   //Plays the BoxShrink animation
            gameObject.GetComponent<Animation>().Play("BoxShrink");

            timer++;

            if (timer == 5)//int is the same length as animation (int 5 = 0.05 secs) - stops it looping
            {
                Destroy(this.gameObject);//Destroys box
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {   //Adds collision between the Players Bullet and the Box this script is attached to
        if (col.gameObject.tag == "Bullet")
        {
            BoxHit = true;
        }
    }
}