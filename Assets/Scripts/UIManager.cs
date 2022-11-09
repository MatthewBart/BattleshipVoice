using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// this class is for handling the games UIs
// specifically the options, main menu command and for when the game ends
public class UIManager : MonoBehaviour
{

    // game objects
    [SerializeField] public GameObject options;
    [SerializeField] public GameObject menu;
    [SerializeField] public GameObject youWin;
    [SerializeField] public GameObject youLose;
    [SerializeField] public GameObject gameBoard;
    [SerializeField] public GameObject tutorial;

    // bools
    public bool optionsEnabled;
    public bool gameOver;
    public bool gameWon;

    // Loads the Main Menu
    public void Menu()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    // for handling the options UI
    public void Options()
    {
        // if current scene isnt the Main Menu and the game isnt over
        // Enable options depending on value of the optionsEnabled bool
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "MainMenu")
        {
            if (gameOver != true)
            {
                if (optionsEnabled == false)
                {
                    options.SetActive(true);
                    optionsEnabled = true;
                    gameBoard.SetActive(false);
                }
                else
                {
                    gameBoard.SetActive(true);
                    options.SetActive(false);
                    optionsEnabled = false;
                }
            }
        }
    }

    // Handles the game results
    public void GameEnd()
    {
        // sets gameOver variable to true
        gameOver = true;
        // for when the player wins
        if(gameWon == true)
        {
            youWin.SetActive(true);
            gameBoard.SetActive(false);

        }
        // for when the player loses
        else if (gameWon == false)
        {
            youLose.SetActive(true);
            gameBoard.SetActive(false);
        }
    }

}
