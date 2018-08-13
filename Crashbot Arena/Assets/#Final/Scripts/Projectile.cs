using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [Header("Projectile Config")]
    public float Range;
    public float Speed;
    public float Damage;
    public bool IsPlayerProjectile;
    public bool SpawnOnDestroy;
    public GameObject SpawnableObject;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, Range);
	}
	
	// Update is called once per frame
	void Update () {
        //move the object forward, relative to itself
        transform.Translate(Vector3.up * Speed *Time.deltaTime, Space.Self);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsPlayerProjectile)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.SendMessage("ApplyDamage", Damage);
            }
        }
        else
        {
            if(collision.gameObject.tag == "Player")
            {
                GameObject.Find("GameManager").SendMessage("DamagePlayer", Damage);
            }
        }
        //TODO add posibility of spawning something
        Destroy(gameObject);
    }
}
