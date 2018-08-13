using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("Player Health")]
    public int IN_PlayerHealth;
    public int IN_PlayerMaxHealth;
    [Header("PlayerScore")]
    public int IN_PlayerScore;
    public int IN_PlayerHighScore;
    //Gamestate Enum
    public enum GameState
    {
        Start,
        Playing,
        GameOver,
        Pause,
    }
    [Header("GameState")]
    [SerializeField]
    public GameState GM_GameState = GameState.Start;
    [Header("Menu UI")]
    public GameObject MainMenu;
    public GameObject GameUI;
    [Header("Game Setup")]
    public GameObject Player;
    public Transform PlayerRespawn;
	// Use this for initialization
	void Start () {
        //Set up all the things that the game should be set up as when the game is starting!
        IN_PlayerHealth = IN_PlayerMaxHealth;
        //Sets the Game start to the main menu
        GM_GameState = GameState.Start;

        //Handles the high score!
        ScoreChecker();
	}
	
	// Update is called once per frame
	void Update () {
		//Game State determines which to use
        if(GM_GameState == GameState.Start)
        {
            GameStart();
        }
        else if (GM_GameState == GameState.Playing)
        {
            Playing();
        }
        else if (GM_GameState == GameState.Pause)
        {
            Pause();
        }
        else if (GM_GameState == GameState.GameOver)
        {
            GameOver();
        }
        else
        {
            //errr...How did you get to here? ERRRRRRRRRR
            Debug.Log("ERROR - INCORRECT GAMESTATE! ERRRRR ERRR ERRR");
        }
    }
    #region Game States
    //Game States 
    //Basically, the function to loop through when in these various states.
    void GameStart()
    {
        //Do stuff that should be avalible during the start menu!
    }
    void Playing()
    {
        CheckHealth();
    }
    void Pause()
    {
        //Do paused game things, like change the audio to be slightly-muted!
    }
    void GameOver()
    {
        //Do Game Over things!
    }
    #endregion
    #region Game Functions
    //Game functions
    public void CheckHealth()
    {
        //if the health is = to 0 or less than 0, game over.
        if(IN_PlayerHealth <= 0)
        {
            //Enable the game over menu
            MainMenu.SetActive(true);
            //Set play health back up to max
            IN_PlayerHealth = IN_PlayerMaxHealth;
            //Switch to GameOver state.
            GM_GameState = GameState.GameOver;
            //Handles the high score!
            ScoreChecker();
        }
    }
    //Healing the player
    public void Healplayer(int in_HealthPack)
    {
        if(IN_PlayerHealth + in_HealthPack >= IN_PlayerMaxHealth)
        {
            IN_PlayerHealth = IN_PlayerMaxHealth;
        }
        else
        {
            IN_PlayerHealth += in_HealthPack;
        }
    }
    //hurting the player
    public void DamagePlayer(int Damage)
    {
        IN_PlayerHealth -= Damage;
    }
    //Score increase
    public void ScoreIncrease(int scoreplus)
    {
        IN_PlayerScore += scoreplus;      
    }
    #endregion
    #region Menu Functions
    //Lot of resetting and such!
    public void StartGame()
    {
        MainMenu.SetActive(false);
        GameUI.SetActive(true);
        IN_PlayerScore = 0;
        Player.transform.position = PlayerRespawn.position;
        Player.transform.rotation = PlayerRespawn.rotation;
        //And also, set the game state!
        GM_GameState = GameState.Playing;
    }
    public void ScoreChecker()
    {
        //Script deals with player prefs, which are values that are saved externally to the game.
        //This means, they'll be saved betwen play sessions, so good for a high score.

        //Check if the high score has been set yet
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            //update with the current score if it hasn't.
            PlayerPrefs.SetInt("HighScore", IN_PlayerScore);
        }
        //if it has
        else
        {
            //Check if the current score is better than the high score
            if(IN_PlayerScore > PlayerPrefs.GetInt("HighScore"))
            {
                //if it is, update to the new high score!
                PlayerPrefs.SetInt("HighScore", IN_PlayerScore);
            }
        }
        //And finally, update the high score to the Playerpref
        IN_PlayerHighScore = PlayerPrefs.GetInt("HighScore");
    }
    #endregion
}
