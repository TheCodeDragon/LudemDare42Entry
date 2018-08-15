using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectScript : MonoBehaviour {
    public PC_DefaultGun[] Guns;
    public int WeaponIndex = 0;
	// Use this for initialization
	void Start () {
        //disable the rest
        foreach (PC_DefaultGun Gun in Guns)
        {
            Gun.IsSelected = false;
        }
        //enable the first, aka, the default.
        Guns[0].IsSelected = true;
	}
    void Update()
    {
        //Remeber, arrays start at 0, and 'Next' means to cycle up, 'Previous' means to cycle down.
        if(Input.GetButtonDown("SelectNext"))
        {
            //So, if there's 6 weapons, we want to know if it's at 5
            if(WeaponIndex == Guns.Length - 1)
            {
                WeaponIndex = 0;
            }
            //Whilst it's not there, make it this.
            else
            {
                WeaponIndex++;
            }
            //And update what weapon is selected.
            UpdateSelection(WeaponIndex);
        }
        if(Input.GetButtonDown("SelectPrevious"))
        {
            //if it's at 0, we need to put it at the last index
            if(WeaponIndex == 0)
            {
                WeaponIndex = Guns.Length - 1;
            }
            //otherwise, decrement it by 1
            else
            {
                WeaponIndex--;
            }
        }
    }
    void UpdateSelection(int index)
    {
        //disable the rest
        foreach (PC_DefaultGun Gun in Guns)
        {
            Gun.IsSelected = false;
        }
        //enable the active.
        Guns[WeaponIndex].IsSelected = true;
    }
}
