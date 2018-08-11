using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StandardBullet : MonoBehaviour {

    //bullet attributes
    [Header("Bullet Config")]
    public float range;
    public float speed;
    public float damage;
    //is it a player weapon?
    public bool isPlayerBullet;
    

	// Use this for initialization
	void Start () {
        //destroy game object after range time
        Destroy(gameObject, range);


	}
    void Update()
    {
        transform.Translate(transform.up * speed, Space.Self);
    }
    // Collision damage and destruction
    void OnCollisionEnter2D(Collision2D col)
    {
        //check if this belongs to the player or not
        if(isPlayerBullet)
        {
            if (col.gameObject.tag == "Enemy")
            {
                // Deak danage to foe
                col.gameObject.SendMessage("ApplyDamage", damage);
            }
        }
        else
        {
            //check it hit the player
            if(col.gameObject.tag == "Player")
            {
                //Deal Damage
                GameObject.Find("GameManager").SendMessage("DamagePlayer", damage);
            }
        }
        //Delete bullet.
        Destroy(gameObject);
    }


}
