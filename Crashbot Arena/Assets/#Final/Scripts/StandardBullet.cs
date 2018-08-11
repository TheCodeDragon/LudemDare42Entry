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
		
	}
	
	// Update is called once per frame
	void Update () {

        rbBullet.velocity = transform.forward * speed;

        float currentAirTime = 0;

        if (currentAirTime < range)
            currentAirTime += Time.deltaTime;

        if (currentAirTime > range)
            Destroy(gameObject); 


    }
  

    // Collision damage and destruction
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
            // Deak danage to foe
            col.gameObject.SendMessage("ApplyDamage", damage);

        Destroy(gameObject);

    }


}
