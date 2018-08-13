using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {
    private GameManager GM;
    public string ST_ScorePrefix;
    public Text TX_Score;
    public bool isCurrentScore;
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	// Update is called once per frame
	void Update () {
        if(isCurrentScore)
        {
            TX_Score.text = ST_ScorePrefix + GM.IN_PlayerScore.ToString();
        }
        else
        {
            TX_Score.text = ST_ScorePrefix + GM.IN_PlayerHighScore.ToString();
        }
	}
}
