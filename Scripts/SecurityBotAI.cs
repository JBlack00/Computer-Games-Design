using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Liminal Space
/// This script is attached to the Security Bot.
/// This makes the bot follow the player.
/// This script contains the enemies health.
/// </summary>

public class SecurityBotAI : MonoBehaviour
{
    public PlayerScore playerScoreScript;
    public GameObject target;//Player
    public GameObject prefabExplosion;//Explosion particle system
    private float targetDistance;//Distance from the target (player)
    private int lookDistance = 1000;//Distance the enemy can see
    private int followDistance = 500;//Distance the enemy can follow
    private int movementSpeed = 1;//Enemy movement speed
    private int rotationSpeed = 1;//Speed the enemy rotates to face the player
    private int securityBotHealth = 10;

    // Use this for initialization
    void Start()
    {
        playerScoreScript = GameObject.Find("FPSController").GetComponent<PlayerScore>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        TargetDistance();
    }

    private void TargetDistance()
    {
        targetDistance = Vector3.Distance(target.transform.position, transform.position);
        //If target distance is less than look distance
        if (targetDistance < lookDistance)
        {
            LookAtPlayer();//Call LookAtPlayer method
        }
        //If target distance is less than the follow distance
        if (targetDistance < followDistance)
        {
            FollowPlayer();//Call FollowPlayer method
        }
    }

    private void LookAtPlayer()
    {   //Rotates to face player
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void FollowPlayer()
    {   //Moves towards player
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {   //Decreases enemy health
        if (col.gameObject.tag == "Bullet")
        {
            securityBotHealth -= 1;
            //Destroys enemy when its health = 0
            if (securityBotHealth == 0)
            {
                playerScoreScript.SecurityBotScoreIncrease();
                //Spawns explosion particle system
                prefabExplosion = Instantiate(prefabExplosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(this.gameObject);//Destroys enemy
                Destroy(prefabExplosion, 5);//Destroys explosion particle system
            }
        }
    }
}