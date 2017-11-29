using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Liminal Space
/// This script is attached to each of the buttons that are interactable in the menus.
/// This script is what loads the various scenes when the buttons in the menus are clicked.
/// </summary>

public class MenuSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
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
    public Pause pauseScript;
    public string level;//The number of build level that the button will load (Change in inspector)
    public bool playButton;
    public bool resumeButton;
    public bool quitButton;

    //Accessed through the inspector OnClick function
    public void OnMouseDown()
    {
        if (playButton == true)
        {
            SceneManager.LoadScene("ClinicalArea");//Loads clinical area scene
        }
        if (quitButton == true)
        {
            SceneManager.LoadScene("MainMenu");//Loads Main Menu
            Destroy(player.gameObject);//Destroys player when main menu loads so there aren't 2 cameras etc in the scene
            Destroy(canvas.gameObject);//Destroys canvas when main menu loads so there aren't 2 canvases in the scene
            Cursor.visible = true;//Shows cursor
        }
        if (resumeButton == true)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;//Pauses game
                pauseScript.PauseToggle();//Calls PauseToggle method within the Pause script
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;//Unpauses game
                pauseScript.PauseToggle();//Calls PauseToggle method within the Pause script
            }
        }
    }
}

