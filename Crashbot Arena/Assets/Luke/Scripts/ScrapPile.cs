using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPile : MonoBehaviour {
    //Sprite array to randomly set the sprite.
    public Sprite[] ScrapPileSprites;
    // Use this for initialization
    void Start()
    {
        //Get a reference to the renderer.
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        //Randomly set the sprite.
        SR.sprite = ScrapPileSprites[Random.Range(0, ScrapPileSprites.Length)];
    }
    private void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().GM_GameState != GameManager.GameState.Playing)
        {
            Destroy(gameObject);
        }
    }
}
