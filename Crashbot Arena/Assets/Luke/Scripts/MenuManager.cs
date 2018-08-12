using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    [Header("Menu List")]
    public GameObject[] Menus;
    public GameObject MainMenu;
	// Use this for initialization
	void Start () {
        //enable the main menu 
        MainMenu.SetActive(true);
        //disable the rest
        foreach (GameObject Menu in Menus)
        {
            Menu.SetActive(false);
        }
    }
    public void ChangeMenu(int menuindex)
    {
        //disable all Menues.
        //Disable main menu
        MainMenu.SetActive(false);
        //disable rest
        foreach (GameObject Menu in Menus)
        {
            Menu.SetActive(false);
        }
        //enable menu
        Menus[menuindex].SetActive(true);

    }
    public void ChangeToMainMenu()
    {
        //repeat what happened for the start
        MainMenu.SetActive(true);
        foreach (GameObject Menu in Menus)
        {
            Menu.SetActive(false);
        }
    }
    //exit the game
    public void ExitGame()
    {
        Application.Quit();
        //Leave debug
        Debug.Log("I QUIT!");
    }
}
