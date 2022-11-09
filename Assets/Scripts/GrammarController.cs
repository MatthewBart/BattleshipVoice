using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;  // for stringbuilder
using UnityEngine;
using UnityEngine.Windows.Speech;   // grammar recogniser
using System.Linq;
using UnityEngine.SceneManagement;


// Handles the games grammars and actions involved
public class GrammarController : MonoBehaviour
{
    // keywords
    [SerializeField] private string[] keywords;

    private KeywordRecognizer kr;

    // Action is in System, using System; or System.Action
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Confidence Level
    private ConfidenceLevel confidenceLevel = ConfidenceLevel.Medium;

    private string spokenWord = "";

    void Start()
    {
        // Actions
        actions.Add("1", SelectPiece);
        actions.Add("2", SelectPiece);
        actions.Add("3", SelectPiece);
        actions.Add("4", SelectPiece);
        actions.Add("5", SelectPiece);
        actions.Add("6", SelectPiece);
        actions.Add("7", SelectPiece);
        actions.Add("8", SelectPiece);
        actions.Add("9", SelectPiece);
        actions.Add("10", SelectPiece);
        actions.Add("11", SelectPiece);
        actions.Add("12", SelectPiece);
        actions.Add("13", SelectPiece);
        actions.Add("14", SelectPiece);
        actions.Add("15", SelectPiece);
        actions.Add("16", SelectPiece);
        actions.Add("17", SelectPiece);
        actions.Add("18", SelectPiece);
        actions.Add("19", SelectPiece);
        actions.Add("20", SelectPiece);
        actions.Add("21", SelectPiece);
        actions.Add("22", SelectPiece);
        actions.Add("23", SelectPiece);
        actions.Add("24", SelectPiece);
        actions.Add("25", SelectPiece);
        actions.Add("26", SelectPiece);
        actions.Add("27", SelectPiece);
        actions.Add("28", SelectPiece);
        actions.Add("29", SelectPiece);
        actions.Add("30", SelectPiece);
        actions.Add("31", SelectPiece);
        actions.Add("32", SelectPiece);
        actions.Add("33", SelectPiece);
        actions.Add("34", SelectPiece);
        actions.Add("35", SelectPiece); 
        actions.Add("36", SelectPiece);
        actions.Add("Ok", SelectPiece);
        actions.Add("Start", StartGame);
        actions.Add("Options", Options);
        actions.Add("Return", Options);
        actions.Add("Replay", StartGame);
        actions.Add("Exit", Options);
        actions.Add("Quit", Exit);
        actions.Add("Menu", Exit);
        actions.Add("Okay", Okay);

        if (keywords != null)
        {
            kr = new KeywordRecognizer(actions.Keys.ToArray(), confidenceLevel);
            kr.OnPhraseRecognized += KR_OnPhraseRecognized;
            kr.Start();
        }
    }

    // handles when game picks up a phrase 
    private void KR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        spokenWord = args.text;
        actions[spokenWord].Invoke();
    }

    // == Actions Methods ==
    // calls the select tile method from the BattleshipGameHandler script
    private void SelectPiece()
    {
        // only calls when not on main menu
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            gameObject.GetComponent<BattleshipGameHandler>().SelectTile(spokenWord);
        }
    }

    // Starts the gane
    private void StartGame()
    {
        // can be called when main menu is true
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        // used for the Replay command 
        // calls start when gameOver is true
        else if(gameObject.GetComponent<UIManager>().gameOver == true)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        } 
        
    }

    // Exits the game
    private void Exit()
    {
        // loads the mainmenu from the gameover bool is true
        if (SceneManager.GetActiveScene().name != "MainMenu" && gameObject.GetComponent<UIManager>().gameOver == true)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        // disables the options object when on object menu
        else if (gameObject.GetComponent<UIManager>().optionsEnabled == true)
        {
            gameObject.GetComponent<UIManager>().Options();
        }
        else
        {
            // quits the game
            Application.Quit();
        }

    }

    // calls options 
    private void Options()
    {
        // Calls options only if not on mainmenu
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            gameObject.GetComponent<UIManager>().Options();
        }
    }

    // Sets tutorial to false and menu to true when called
    private void Okay()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" )
        {
            gameObject.GetComponent<UIManager>().menu.SetActive(true);
            gameObject.GetComponent<UIManager>().tutorial.SetActive(false);
        }
    }
       


    // shuts off grammar recogniser when application ends
    private void OnApplicationQuit()
    {
        if (kr != null && kr.IsRunning)
        {
            kr.OnPhraseRecognized -= KR_OnPhraseRecognized;
            kr.Stop();
        }
    }
}