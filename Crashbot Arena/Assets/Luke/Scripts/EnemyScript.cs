using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    //ho boy. This script is going to do, a LOT.
    //Step one, move towards player.
    //Find player: 
    private GameObject GO_Player;
    //And find the Game Manager:
    private GameManager GM;
    //and the attack cooldown
    private float timer;
    [Header("Enemy Config")]
    public float MoveSpeed;
    public float AttackRange;
    public float Health;
    [Header("Specials")]
    public bool DestroyScrap;
    [Header("Attack Config")]
    public GameObject Projectile;
    public Transform SpawnPoint;
    public float AttackCooldown;
    [Header("Death Config")]
    public bool SpawnObject;
    public GameObject[] Spawnobjects;
	// Use this for initialization
	void Start () {
        GO_Player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
        //
        //Check the game state!
        if(GM.GM_GameState == GameManager.GameState.Playing)
        {
            //Health check!
            DeathCheck();
            //movement
            EnemyMove();
            //attack
            EnemyAttack();
            
        }
        //Clean up if it's not!
        else
        {
            Destroy(gameObject);
        }
	}
    void EnemyMove()
    {
        //TODO: Make them move smarter?
        //Calculate where the player is
        Vector2 V2_LookDirection = GO_Player.transform.position - transform.position;
        //look towards them!
        transform.up = V2_LookDirection;
        //Check if you're in attack range
        if(Vector2.Distance(transform.position, GO_Player.transform.position) > AttackRange*2)
        {
            //Move Forward!
            transform.position = Vector2.MoveTowards(transform.position, GO_Player.transform.position, MoveSpeed * Time.deltaTime);
        }
    }
    //Enemy attack function
    void EnemyAttack()
    {
        //if the timer is 0
        if(timer <= 0)
        {
            //check if the mech is in attack range
            if (Vector2.Distance(transform.position, GO_Player.transform.position) < AttackRange)
            {
                //Attack! Fire Weapons!
                Instantiate(Projectile, SpawnPoint.position, SpawnPoint.rotation);
                //reset cooldown
                timer = AttackCooldown;
            }
        }
        //timer count down
        else
        {
            timer -= Time.deltaTime;
        }

    }
    //Health management
    void DeathCheck()
    {
        //run out of health?
        if(Health <= 0)
        {
            if(SpawnObject)
            {
                //Spawn the backlog!
                foreach (GameObject spawn in Spawnobjects)
                {
                    Instantiate(spawn, transform.position, transform.rotation);
                }
            }
            //Destroy mech
            Destroy(gameObject);
        }
    }
    //The function to call to deal damage.
    public void ApplyDamage(float dmg)
    {
        Health -= dmg;
    }
}
