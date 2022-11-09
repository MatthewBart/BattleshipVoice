using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLives : MonoBehaviour
{
    [SerializeField] public GameObject gameController;
    public Text myText;
    string livesString;
    private int currentLives;
    private int currentShipPieces;
    // Update is called once per frame

    void Update()
    {
        currentLives= gameController.GetComponent<BattleshipGameHandler>().lives;
        currentShipPieces = gameController.GetComponent<BattleshipGameHandler>().shipPieces;
        livesString = currentLives.ToString();
        myText.text = "Lives: " + livesString + "               Ship Pieces left: " + currentShipPieces;

    }

}

