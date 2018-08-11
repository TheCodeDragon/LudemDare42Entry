using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHole : MonoBehaviour {
    public Sprite[] HoleSprites;
	// Use this for initialization
	void Start () {
        //Randomly applies the sprite chosen
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        SR.sprite = HoleSprites[Random.Range(0, HoleSprites.Length)];
	}

    private void OnTriggerEnter2D(Collider2D colObj)
    {
        if (colObj.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").SendMessage("DamagePlayer", 200);
        }
        else
        {
            colObj.SendMessage("TakeDamage", 50);
        }
    }
}
