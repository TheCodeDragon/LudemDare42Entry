using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StandardBullet : MonoBehaviour {

    //bullet attributes
    [Header("Bullet Config")]
    public float range;
    public float speed;
    public float damage;
    //rigidbody
    Rigidbody2D rbBullet;

	// Use this for initialization
	void Start () {

        //asign rigidbody
        rbBullet = GetComponent<Rigidbody2D>();
        //add a force to the bullet.
        //Since there is no friction, the bullet will travel at this speed.
        rbBullet.AddRelativeForce(transform.up * speed);
        //destroy game object after range time
        Destroy(gameObject, range);


	}
    // Collision damage and destruction
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // Deak danage to foe
            col.gameObject.SendMessage("ApplyDamage", damage);
        }
        Destroy(gameObject);
    }


}
