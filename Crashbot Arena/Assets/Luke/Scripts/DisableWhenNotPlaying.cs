using UnityEngine;
public class DisableWhenNotPlaying : MonoBehaviour {
    private GameManager GM;
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GM.GM_GameState != GameManager.GameState.Playing)
        {
            gameObject.SetActive(false);
        }
	}
}
