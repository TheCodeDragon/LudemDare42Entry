using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWhenWalking : MonoBehaviour {
    Rigidbody2D RB;
    public AudioSource AS_Audio;
	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position )
        {
            AS_Audio.Play();
        }
        else
        {
            AS_Audio.Pause();
        }
	}
}
