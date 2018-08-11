using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_DefaultGun : MonoBehaviour {


    // Active Weapon
    public bool activeWeapon = true;

    // Stats for shoosting
    public float rateOfFire = 2;
    public bool canShoot = true;

    // Bullet GO
    public GameObject bullet;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        // Run shooting cooldown whenever weapon canShoot = false
        if (canShoot == false)
            // check to see if time passed since last shoot is over cooldown
            if (rateOfFire > 0)

                rateOfFire -= Time.deltaTime;

        // set to can shoot again
        if (rateOfFire < 0)

            canShoot = true;           

    }

    // PC shoot script
    void PCShoot () {

        // if this is the active weapon
        if (activeWeapon == true)

            //on button press
            if (Input.GetButtonDown("Fire1") && canShoot == true)

                // instantiate bullet
                Instantiate(bullet, transform.position+(transform.forward*2), transform.rotation);
                // turn cooldown on
                canShoot = false;
               

    }


}
