using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject TrackingTarget;
    public float ZOffset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Doesn't need to do anything else, really.
        transform.position = new Vector3(TrackingTarget.transform.position.x, TrackingTarget.transform.position.y, ZOffset);

    }
}
