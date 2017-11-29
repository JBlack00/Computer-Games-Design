using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the enemy spawners.
/// It spawns enemies in waves.
/// </summary

public class EnemySpawner : MonoBehaviour
{
    public GameObject SpikeBot;//Enemy
    public GameObject spawnPoint;//Number of the spawn point
    public GameObject[] enemies;//Array for multiple enemies
    public GameObject HexCodeSpawner;
    private int numEnemies;//Number of live enemies
    private int numWave;//Number of wave
    private int waveCounter;
    private int waveCounterReset;
    private int doorTimer;
    private bool newWave;//Checks if new wave has started

    // Use this for initialization
    void Start()
    {
        waveCounterReset = 1;//Sets waveCounterReset to 1
        waveCounter = 1;//Sets waveCounter to 1
        numWave = 0;//Sets numWave to 0
        SpawnEnemy();//Calls spawnEnemy method
        NewWave();//Calls NewWave method
        doorTimer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Waves();
    }

    private void Waves()
    {
        if (waveCounter == 0)
        {
            NewWave();//Calls NewWave method
        }

        if (newWave == true)
        {
            WaveSettings();//Calls WaveSettings method
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemies = enemies.Length;

        if (numEnemies == 0 && numWave < 3)
        {
            newWave = true;
        }

        if (numEnemies == 0 && numWave >= 3)
        {
            doorTimer++;

            if (doorTimer == 2)
            {
                HexCodeSpawner.SetActive(true);//Activates the HexCodeSpawner game obj
            }
        }
    }

    private void SpawnEnemy()
    {
        //Spawn points
        if (this.gameObject.name == ("Spawner1"))
        {
            spawnPoint = this.gameObject;
        }
        if (this.gameObject.name == ("Spawner2"))
        {
            spawnPoint = this.gameObject;
        }
        if (this.gameObject.name == ("Spawner3"))
        {
            spawnPoint = this.gameObject;
        }
        if (this.gameObject.name == ("Spawner4"))
        {
            spawnPoint = this.gameObject;
        }
        if (this.gameObject.name == ("Spawner5"))
        {
            spawnPoint = this.gameObject;
        }
        if (this.gameObject.name == ("Spawner6"))
        {
            spawnPoint = this.gameObject;
        }
        Instantiate(SpikeBot, spawnPoint.transform.position, Quaternion.identity);//Spawn enemy at spawn point location
    }

    private void WaveSettings()
    {   
        if (numWave >= 0 && numWave < 4)
        {
            waveCounterReset = 1;//Resets counter
            SpawnEnemy();//Calls SpawnEnemy method
            waveCounter = waveCounter - 1;
            newWave = false;
        }
    }

    private void NewWave()
    {
        //Increase wave number by 1
        numWave = numWave + 1;
        waveCounter = waveCounterReset;
    }

    private void Win()
    {   //Ends the waves - Victory Condition
        if (numWave >= 3)
        {
            newWave = false;
        }
    }
}
