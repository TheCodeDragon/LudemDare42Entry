using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_DefaultGun : MonoBehaviour {
    // Stats for shoosting
    public float rateOfFire = 2;
    private float timer;
    // Bullet GO
    public GameObject bullet;
    public Transform TR_Muzzle;
    private GameManager GM;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = 0;
    }
    // Update is called once per frame
    void Update ()
    {
        if(GM.GM_GameState == GameManager.GameState.Playing)
        {
            PCShoot();
        }
    }

    // PC shoot script
    void PCShoot ()
    {
        //if the timer is 0
        if (timer <= 0)
        {
            //check if player shoots
            if (Input.GetButtonDown("Fire1"))
            {
                //Attack! Fire Weapon!
                Instantiate(bullet, TR_Muzzle.position, TR_Muzzle.rotation);
                //reset cooldown
                timer = rateOfFire;
            }
        }
        //timer count down
        else
        {
            timer -= Time.deltaTime;
        }
    }


}
