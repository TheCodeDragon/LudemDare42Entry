﻿using System.Collections;
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
    public int DefeatScore;
    [Header("Specials")]
    public bool DestroyScrap;
    [Header("Attack Config")]
    public GameObject Projectile;
    public Transform SpawnPoint;
    public float AttackCooldown;
    [Header("Death Config")]
    public bool SpawnObject;
    public GameObject[] Spawnobjects;
    [Header("Audio config")]
    public AudioSource AS_Walking;
    public AudioSource AS_Shooting;

    // Animator             ---------------------------- animator va ------------------------
    //Animator anim;

    // Use this for initialization
    void Start () {
        GO_Player = GameObject.FindGameObjectWithTag("Player");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        // get attached animator  --------------------- animator stuff ----------------------
        //anim = GetComponent<Animator>();
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
        //Check if you're outside attack range
        if (Vector2.Distance(transform.position, GO_Player.transform.position) > AttackRange)
        {
            //Move Forward!     ------------ Animator Triggers ----------------
            //Since the mech is moving towards the player, is the walking bool true? if not...
            //if(!anim.GetBool("IsWalking"))
            //{
                //make it so.
                //anim.SetBool("IsWalking", true);
            //}
            transform.position = Vector2.MoveTowards(transform.position, GO_Player.transform.position, MoveSpeed * Time.deltaTime);
            //Handle the audio
            if(!AS_Walking.isPlaying)
            {
                AS_Walking.Play();
            }
        }
        //This means that you're within attack range
        else
        {
            //so, if you're walking still...
            //if (anim.GetBool("IsWalking"))
            //{
            //Don't.
            //anim.SetBool("IsWalking", false);
            //}
            //And the audio here
            AS_Walking.Stop();
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
                //And make noise
                AS_Shooting.PlayOneShot(AS_Shooting.clip);
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
            //Spawn the backlog if it spawns stuff
            if (SpawnObject)
            {
                foreach (GameObject spawn in Spawnobjects)
                {
                    Instantiate(spawn, transform.position, transform.rotation);
                }
            }
            //add the score to the GM
            GM.ScoreIncrease(DefeatScore);
            //Destroy mech
            Destroy(gameObject);
        }
    }
    //The function to call to deal damage.
    public void ApplyDamage(float dmg)
    {
        Health -= dmg;
    }

    //Scrap destroyer
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the enemy is a scrap cleaner
        if(DestroyScrap)
        {
            //check the collision for the scrap tag
            if (collision.gameObject.tag == "Scrap")
            {
                //clean up
                Destroy(collision.gameObject);
            }
        }
    }
}
