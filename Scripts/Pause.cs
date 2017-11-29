using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Liminal Space
/// This script is attached to the player FPS Controller.
/// It allows the player to pause and unpause the game.
/// </summary>

public class Pause : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public GameObject player;
    public Image HUD;
    public Image Crosshair;
    public Image PauseBackground;
    public Image ResumeButton;
    public Image QuitButton;
    public Text ResumeText;
    public Text QuitText;
    public Text PauseText;
    public Text SyncText;
    public Slider SyncBar;
    public Slider HealthBar;
    public Slider WeaponBar;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        //Pauses and unpauses game when player presses Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Cursor.visible = true;//Shows cursor
                Time.timeScale = 0;//Pauses game
                PauseToggle();//Calls the PauseToggle method
            }
            else if (Time.timeScale == 0)
            {
                Cursor.visible = false;//Hides cursor
                Time.timeScale = 1;//Unpauses game
                PauseToggle();//Calls the PauseToggle method
            }
        }
    }

    public void PauseToggle()
    {       //Toggles pause UI on and off so that HUD doesn't show on pause screen
            PauseBackground.enabled = !PauseBackground.enabled;
            ResumeButton.enabled = !ResumeButton.enabled;
            QuitButton.enabled = !QuitButton.enabled;
            HUD.enabled = !HUD.enabled;
            Crosshair.enabled = !Crosshair.enabled;
            SyncBar.enabled = !SyncBar.enabled;
            HealthBar.enabled = !HealthBar.enabled;
            WeaponBar.enabled = !WeaponBar.enabled;
            PauseText.enabled = !PauseText.enabled;
            ResumeText.enabled = !ResumeText.enabled;
            QuitText.enabled = !QuitText.enabled;
            SyncText.enabled = !SyncText.enabled;
    }
}
