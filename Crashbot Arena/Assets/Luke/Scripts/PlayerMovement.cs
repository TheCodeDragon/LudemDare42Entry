using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Movement Config")]//Header tag!
    public float fl_MoveSpeed;//Movement in absolute, W/S up and down, A/D left and right.
    public bool bl_CanMove;//In case of stun
	
	// Update is called once per frame
	void Update () {
        //Check if can move
        if (bl_CanMove)
        {
            //Then move
            //Depreciated, locks on to mouse location and move relative to it:
            //MoveRelativeToMouse();
            //Actual movement
            MoveInworld();
            //And rotate
            LookAtMouse();
        }
	}
    //Movement Scripts
    void MoveRelativeToMouse()
    {
        //Capture the input axies
        Vector2 V2Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //apply the transform
        transform.Translate(V2Movement*fl_MoveSpeed*Time.deltaTime);
    }
    void MoveInworld()
    {
        //Capture the input axies
        Vector2 V2Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //apply the transform to worldspace
        transform.Translate(V2Movement * fl_MoveSpeed * Time.deltaTime, Space.World);
    }


    void LookAtMouse()
    {
        //Get Mouse position on screen
        Vector3 V3MousePos = Input.mousePosition;
        //Convert from screen space to world position
        V3MousePos = Camera.main.ScreenToWorldPoint(V3MousePos);
        //Set up the direction
        Vector2 V2Lookdirection = new Vector2(
            V3MousePos.x - transform.position.x,
            V3MousePos.y - transform.position.y
            );
        //look in that direction
        transform.up = V2Lookdirection;
    }
}
