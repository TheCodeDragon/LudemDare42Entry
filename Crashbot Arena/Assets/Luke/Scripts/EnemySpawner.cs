﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [Header("Spawn Config")]
    public GameObject[] Enemies;
    public Transform[] Spawnlocations;
    public int spawnFrequency;
    public bool bl_Canspawn;
    private float timer;
    // Use this for initialization
    void Start () {
        timer = spawnFrequency;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(timer <= 0 )
        {
            if(bl_Canspawn)
            {
                //do spawning!
                Spawn();
                timer = spawnFrequency;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
    void Spawn()
    {
        //pick a random enemy
        GameObject enemy = Enemies[Random.Range(0, Enemies.Length)];
        //pick a random spawn location
        Transform SpawnLoc = Spawnlocations[Random.Range(0, Spawnlocations.Length)];
        //spawn the enemy in the location!
        Instantiate(enemy, SpawnLoc.position, SpawnLoc.rotation);
    }
}
