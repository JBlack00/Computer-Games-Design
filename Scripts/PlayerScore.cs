using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Liminal Space
/// This script is attached to the player.
/// This increases the players score and displays the score on the screen.
/// </summary>

public class PlayerScore : MonoBehaviour
{
    public PlayerHealth playerHealthScript;
    public GameObject Player;
    public GameObject canvas;
    public GameObject Gem;
    public Image LoseEndScreen;
    public Text LoseEndText;
    public Text scoreText;
    public int Score;
    public int minPoints;
    public float GameOverTimer;
    public float LoadMainMenu;
    public bool gameOver;

    // Use this for initialization
    void Start ()
    {
        Score = 0;
        GameOverTimer = 0;
        minPoints = 0;
        Gem.SetActive(true);
    }

    void Update()
    {
        Gem = GameObject.FindGameObjectWithTag("Gem");
        GameOver();
    }

    public void GameOver()
    {
        if (gameOver == true)
        {
            GameOverTimer++;

            if (GameOverTimer >= 100)
            {
                LoseCondition();

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

    public void LoseCondition()
    {
        LoseEndScreen.enabled = true;
        LoseEndText.enabled = true;
    }


    //This is called when the bullet collides with ShrinkBox
    public void BoxScoreIncrease()
    {   
        Score += 1;//Increases score
        UpdateScore();
    }
    //This is called when the player kills a spike bot
    public void SpikeBotScoreIncrease()
   {
        Score += 5;//Increases score
        UpdateScore();
    }
    //This is called when the player kills a security bot
    public void SecurityBotScoreIncrease()
    {
        Score += 10;//Increases score
        UpdateScore();
    }
    //This is called from the PlayerHealth script and is called when the player has 0 health
    public void ReduceScore()
    {
        if(Score >= 50)
        {
            Score -= 50;//Reduce score
            UpdateScore();
        }  
        if (Score <= minPoints)
        {   //Sets the player score to minPoints (stops it going under 0)
            Score = minPoints;
        }
        //Game Over
        Debug.Log("Game Over");
        gameOver = true;
    }

    public void UpdateScore()
    {
        scoreText.text = " " + Score;//Displays score UI
    }

    void OnTriggerEnter(Collider col)
    {   //Increase score on collision with the gem
        if (col.gameObject.tag == "Gem")
        {
            Score += 50;
            UpdateScore();
            Gem.SetActive(false);
        }
    }
}
