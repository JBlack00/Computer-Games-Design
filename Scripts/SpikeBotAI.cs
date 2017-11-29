using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Liminal Space
/// This script is attached to the Spike Bot.
/// This accesses the NavMeshAgent - setting the enemy values in the inspector (speed, path finding, acceleration, obstacle avoidance).
/// It stops the enemy getting stuck behind obstacles.
/// This script contains the enemies health.
/// </summary>

public class SpikeBotAI : MonoBehaviour
{
    NavMeshAgent agent;//NavMeshAgent in the inspector (controls enemy speed, acceleration, obstacle avoidance, and path finding data)
    public GameObject player;//Object the enemy will follow
    public GameObject prefabExplosion;//Explosion particle system
    public GameObject SpikeBot;
    public PlayerScore playerScoreScript;
    private int spikeBotHealth = 10;//Spike Bot starting health 

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerScoreScript = GameObject.Find("FPSController").GetComponent<PlayerScore>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        LockEnemyPos();
        FollowPlayer();
    }

    private void LockEnemyPos()
    {
        //Locks the enemy on the Y axis to ensure it stays on the ground
        transform.position = new Vector3(transform.position.x, 1.728f, transform.position.z);
        //Locks the enemy on the X and Z axis to stop it falling over
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    private void FollowPlayer()
    {
        //Sets the player as the enemies destination (it will keep following the player)
        agent.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision col)
    {   
        if (col.gameObject.tag == "Bullet")
        {   //Decreases enemy health 
            spikeBotHealth -= 1;
            
            if (spikeBotHealth <= 0)
            {
                playerScoreScript.SpikeBotScoreIncrease();//Calls the SpikeBotScoreIncrease method in the PlayerScore script on collision with bullet
                //Spawns explosion particle system
                prefabExplosion = Instantiate(prefabExplosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(this.gameObject);//Destroys enemy
                Destroy(prefabExplosion, 5);//Destroys explosion particle system
            }
        }
    }
}
