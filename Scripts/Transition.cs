using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the FADE game object (sprite) which is attached to the player.
/// This is enabled when the player is using the portals to switch scenes.
/// </summary>

public class Transition : MonoBehaviour
{
    public Room3Portal teleScript;
    public GameObject FadeScreen;
    public GameObject Player;
    public float fadeTimer = 0;
    public static bool fading;

    // Use this for initialization
    void Start ()
    {
        FadeScreen = GameObject.Find("FADE");//Finds the gameobject called FADE
        FadeScreen.GetComponent<SpriteRenderer>().enabled = false;//Disables FADE
        fading = false;
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if (fading)
        {
            fadeTimer++;

            if (fadeTimer >= 100f)
            {
                FadeScreen.GetComponent<SpriteRenderer>().enabled = false;//Disables FADE
                fading = false;
                fadeTimer = 0;
            }
        }
    }
    public static void HideMe(GameObject Fade)
    {
        Fade.GetComponent<SpriteRenderer>().enabled = true;//Enables FADE
        Transition.fading = true;
    }
}
