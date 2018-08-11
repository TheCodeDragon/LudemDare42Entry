using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StandardBullet : MonoBehaviour {

    //bullet attributes
    public float range = 5;
    public float speed = 5;
    public float damage = 10;

    public Rigidbody2D rbBullet;
    public GameObject goBullet;

	// Use this for initialization
	void Start () {

        //asign rigidbody
        rbBullet = GetComponent<Rigidbody2D>();
        //assign game object
        goBullet = GetComponent<GameObject>();
        //add a force to the bullet.
        //Since there is no friction, the bullet will travel at this speed.
        rbBullet.AddRelativeForce(transform.forward * speed * Time.deltaTime);
        //destroy game object after range time
        Destroy(gameObject, range);


	}
	
	// Update is called once per frame
	void Update () {

    }
  

    // Collision damage and destruction
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // Deak danage to foe
            col.gameObject.SendMessage("ApplyDamage", damage);
        }     
        Destroy(gameObject);

    }


}
