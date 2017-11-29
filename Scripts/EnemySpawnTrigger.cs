using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the enemy spawn trigger (placed at the entrance of the arena area).
/// This activates the spawn points on collision with the player.
/// </summary>

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    public GameObject spawner5;
    public GameObject spawner6;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {   
            spawner1.SetActive(true);
            spawner2.SetActive(true);
            spawner3.SetActive(true);
            spawner4.SetActive(true);
            spawner5.SetActive(true);
            spawner6.SetActive(true);
            
            Destroy(this.gameObject);//Deletes trigger once it has been collided with
        }
    }
}
