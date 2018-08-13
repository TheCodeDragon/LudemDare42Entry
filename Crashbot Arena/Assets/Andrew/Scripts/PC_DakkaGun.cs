using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_DakkaGun : MonoBehaviour {
    // Stats for shoosting
    [Header("Shooting Config")]
    public float rateOfFire = 2;
    public GameObject bullet;
    public Transform TR_Muzzle;
    [Header("Weapon Select config")]
    public bool IsSelected;
    //Weapon graphic
    public GameObject MechGFX;
    //weapon on the UI
    public GameObject UIGFX;
    //reload timer
    private float timer;
    //link to GM
    private GameManager GM;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (GM.GM_GameState == GameManager.GameState.Playing)
        {
            PCShoot();
        }
    }

    // PC shoot script
    void PCShoot()
    {
        //if the timer is 0
        if (timer <= 0)
        {
            //Check that it's selected
            if (IsSelected)
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
        }
        //timer count down
        else
        {
            timer -= Time.deltaTime;
        }
    }
    void UpdateVisuals()
    {
        //if the weapon isn't selected, make it invisible
        if (!IsSelected)
        {
            MechGFX.SetActive(false);
            UIGFX.SetActive(false);
        }
        //if it is, make it visible.
        else
        {
            MechGFX.SetActive(false);
            UIGFX.SetActive(false);
        }
    }


}