using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Liminal Space
/// This script is attached to the player.
/// This script contains the players health, fade transition, glitch effect, and win and lose conditions.
/// </summary>

public class PlayerHealth : MonoBehaviour
{
    public PlayerScore playerScoreScript;
    public GameObject canvas;
    public GameObject Player;
    public GameObject spawner;
    public Image WinEndScreen;
    public Text WinEndText;
    public Slider healthSlider;
    public float playerHealth;
    public float maxHealth = 100f;
    public float GameWonTimer;
    public float LoadMainMenu;
    public int healthTimer;
    public int healthIncreaseDelay;
    public int timer;
    public int glitchTimer;
    public bool glitched;
    public bool Reset = false;
    public bool GameWon;
    public AudioClip glitchSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //disables Camera Glitch component which is attached to the FirstPersonCharacter
        GameObject.Find("FirstPersonCharacter").GetComponent<CameraGlitch>().enabled = false;
        playerHealth = 100f;//Starts player health at 100
        glitchTimer = 0;
        LoadMainMenu = 0;
        timer = 0;
        glitched = false;
        GameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        spawner = GameObject.FindGameObjectWithTag("PlayerSpawner");
        Health();
        ResetPos();
        GameIsWon();
    }

    public void ResetPos()
    {
        if (Reset)
        {
            SetPlayerPos();
        }
    }
 
    public void GameIsWon()
    {
        if (GameWon == true)
        {
            GameWonTimer++;

            if (GameWonTimer >= 100)
            {
                WinCondition();

                LoadMainMenu++;

                if (LoadMainMenu >= 100)
                {
                    SceneManager.LoadScene("MainMenu");//Loads Main Menu
                    Destroy(Player.gameObject);//Destroys player when main menu loads so there aren't 2 cameras etc in the scene
                    Destroy(canvas.gameObject);//Destroys canvas when main menu loads so there aren't 2 canvases in the scene
                }
            }
        }
    }

    public void WinCondition()
    {
        WinEndScreen.enabled = true;
        WinEndText.enabled = true;
    }
    
    public void LoadVirtualRoom1()
    {
        Transition.HideMe(GameObject.Find("FADE"));
        SceneManager.LoadScene("VirtualRoom1");//Loads VirtualRoom1 scene
        Player.transform.position = new Vector3(-43.44f, 2.039f, -45.05001f);//The pos the player will start at in the blue Area
    }

    public void LoadVirtualRoom2()
    {
        Transition.HideMe(GameObject.Find("FADE"));
        SceneManager.LoadScene("VirtualRoom2");//Loads VirtualRoom2 (yellow area) scene
        Player.transform.position = new Vector3(62.22596f, 2f, 284.1526f);//The pos the player will start at in the virtual yellow area
    }

    public void LoadVirtualRoom3()
    {
        Transition.HideMe(GameObject.Find("FADE"));
        SceneManager.LoadScene("VirtualRoom3");//Loads VirtualRoom3 (green area) scene
        Player.transform.position = new Vector3(153.33f, 43.341f, 108.484f);//The pos the player will start at in the virtual green area
    }

    public void LoadVirtualRoom4()
    {
        Transition.HideMe(GameObject.Find("FADE"));
        SceneManager.LoadScene("FinalRoom");//Loads final scene
        Player.transform.position = new Vector3(7.093f, -3.149f, 2.683f);//The pos the player will start at in the final room
    }

    public void Health()
    {
        healthSlider.value = playerHealth;//Sets the health slider UI to the health amount

        if (playerHealth <= 0.0f)
        {
            playerScoreScript.ReduceScore();//Calls the ReduceScore method within the PlayerScore script

            healthIncreaseDelay++;//Increases timer

            if(healthIncreaseDelay == 50)
            {
                playerHealth = 30.0f;//Sets players health to 30
                healthIncreaseDelay = 0;//Resets timer
            }
        }
        if (playerHealth > 0.0f && playerHealth < 100f)
        {
            playerHealth += 0.05f;//Increases the players health very slowly
            healthTimer = 0;//Resets timer
        }

        if (playerHealth >= maxHealth)
        {   //Sets the player health to max health (stops it going over 100)
            playerHealth = maxHealth;
        }   

        if(glitched == true)
        {
            glitchTimer++;

            if (glitchTimer == 50)
            {   //disables Camera Glitch component which is attached to the FirstPersonCharacter
                GameObject.Find("FirstPersonCharacter").GetComponent<CameraGlitch>().enabled = false;
                glitchTimer = 0;
            }
        }
    }

    public void GlitchEffect()
    {   //enables Camera Glitch component which is attached to the FirstPersonCharacter
        GameObject.Find("FirstPersonCharacter").GetComponent<CameraGlitch>().enabled = true;
        glitched = true;
        //Plays audio clip
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = glitchSound;
        audioSource.Play();
    }

    public void SetPlayerPos()
    {
        timer++;
        this.gameObject.transform.position = spawner.transform.position;

        if(timer >= 100)
        {
           Reset = false;
           timer = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {   //Decreases player health
        if (col.gameObject.tag == "HurtPlayer")
        {
            GlitchEffect();
            playerHealth -= 10.0f;
        }
        if (col.gameObject.tag == "BotBullet")
        {
            GlitchEffect();
            playerHealth -= 20.0f;
        }
        if (col.gameObject.tag == "HexStepCollider")
        {
            Reset = true;
            GlitchEffect();
        }
        if (col.gameObject.tag == "GameComplete")
        {
            GameWon = true;
            GlitchEffect();
        }
        if (col.gameObject.tag == "Spike")
        {
            GlitchEffect();
            playerHealth -= 10.0f;
        }
        if (col.gameObject.tag == "TurretBullet")
        {
            GlitchEffect();
            playerHealth -= 10.0f;
        }
    }

    void OnCollisionEnter(Collision col)
    {   //Decreases player health
        if (col.gameObject.tag == "Saw")
        {
            GlitchEffect();
            playerHealth -= 10.0f;
        }
    }
}
