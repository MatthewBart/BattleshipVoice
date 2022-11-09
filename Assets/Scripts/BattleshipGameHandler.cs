 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

// Handles the game methods and determines when the game ends
public class BattleshipGameHandler : MonoBehaviour
{
    // gameobjct
    public GameObject gameBoard;
    // ints and arrays
    private int[,] board = new int[6, 6];
    public int lives = 10;
    public int shipPieces = 0;
    private String[,] tileList = new String[6, 6] {
                                          {"1","2","3","4","5","6"},
                                          {"7","8","9","10","11","12"},
                                          {"13","14","15","16","17","18"},
                                          {"19","20","21","22","23","24"},
                                          {"25","26","27","28","29","30"},
                                          {"31","32","33","34","35","36"}};

    // bools
    bool shipOneGenerated = false;
    bool shipTwoGenerated = false;
    bool shipThreeGenerated = false;

    // Finds the game field
    // Populates the board with battle ships then calculates lives
    void Start()
    {
        gameBoard = GameObject.Find("Game Field");
        PopulateBoard();
        CalculateShipLives();
    }

    // loops through the board then generates battleships
    private void PopulateBoard()
    {
        for(int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                board[i, j] = 0;
            }
        }

        while (shipOneGenerated == false)
        {
            SetShipOne();
        }
        while (shipTwoGenerated == false)
        {
            SetShipTwo();
        }
        while (shipThreeGenerated == false)
        {
            SetShipThree();
        }
    }

    // Creates a verticle ship of 2 blocks high
    private void SetShipOne()
    {
        // Vertical Ship 1 x 2
        Random randInt = new Random();

        int col = randInt.Next(0, 5);
        int row = randInt.Next(0, 5);

        // finds a random col and row
        // checks if the the tile above or below is empty and populates them if possible
        // method is called until a valid spot is found
        if(board[col,row] == 0)
        {
            if ((col + 1) < 6 && board[col + 1, row] == 0)
            {
                board[col, row] = 1;
                board[col + 1, row] = 1;
                shipOneGenerated = true;
            }
            else if ((col - 1) >= 0 && board[col - 1, row] == 0)
            {
                board[col, row] = 1;
                board[col - 1, row] = 1;
                shipOneGenerated = true;
            }
        }
    }

    // Creates a verticle 1 x 3
    private void SetShipTwo()
    {
        // Vertical Ship 1 x 3
        Random randInt = new Random();

        int col = randInt.Next(0, 5);
        int row = randInt.Next(0, 5);

        // finds a random col and row
        // checks if the the tile above or below is empty and populates them if possible
        // method is called until a valid spot is found
        if (board[col, row] == 0)
        {
            if ((row + 1) < 6 && board[col, row + 1] == 0)
            {
                if((row + 2) < 6  && board[col, row + 2] == 0)
                {
                    board[col, row] = 1;
                    board[col, row + 1] = 1;
                    board[col, row + 2] = 1;
                    shipTwoGenerated = true;
                }
                else if((row - 1) >= 0 && board[col, row - 1] == 0)
                {
                    board[col, row] = 1;
                    board[col, row + 1] = 1;
                    board[col, row - 1] = 1;
                    shipTwoGenerated = true;
                }

            }
            else if ((row - 1) >= 0 && board[col, row - 1] == 0)
            {
                if ((row - 2) >= 0 && board[col, row - 2] == 0)
                {
                    board[col, row] = 1;
                    board[col, row - 1] = 1;
                    board[col, row - 2] = 1;
                    shipTwoGenerated = true;
                }
                else if ((row + 1) < 6 &&  board[col, row + 1] == 0)
                {
                    board[col, row] = 1;
                    board[col, row - 1] = 1;
                    board[col, row + 1] = 1;
                    shipTwoGenerated = true;
                }
            }
        }
    }
    // Horizontal Ship 1 x 3
    private void SetShipThree()
    {
        Random randInt = new Random();

        int col = randInt.Next(0, 5);
        int row = randInt.Next(0, 5);

        // finds a random col and row
        // checks if the the tiles above or below is empty and populates them if possible
        // method is called until a valid spot is found
        if (board[col, row] == 0)
        {
            if ((col + 1) < 6 && board[col + 1, row] == 0 )
            {
                if ((col + 2) < 6 && board[col + 2, row] == 0)
                {
                    board[col, row] = 1;
                    board[col + 1, row] = 1;
                    board[col + 2, row] = 1;
                    shipThreeGenerated = true;
                }
                else if ((col - 1) >= 0 &&  board[col - 1, row] == 0)
                {
                    board[col, row] = 1;
                    board[col + 1, row] = 1;
                    board[col - 1, row] = 1;
                    shipThreeGenerated = true;
                }
            }
            else if ((col - 1) >= 0 && board[col - 1, row] == 0)
            {
                if ((col - 2) >= 0 && board[col - 2, row] == 0 )
                {
                    board[col, row] = 1;
                    board[col - 1, row] = 1;
                    board[col - 2, row] = 1;
                    shipThreeGenerated = true;
                }
                else if ((col + 1) < 6 && board[col + 1, row] == 0)
                {
                    board[col, row] = 1;
                    board[col - 1, row] = 1;
                    board[col + 1, row] = 1;
                    shipThreeGenerated = true;
                }
            }
        }
    }

    // Calculates lives based on ship pieces in the game
    private void CalculateShipLives()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if(board[i,j] == 1)
                {
                    shipPieces += 1;
                }
            }
        }
    }

    // checks if the inputted voice command matches the number in the tileList
    // if the tileList value is 1(contains a ship piece)
    // changes colour of the tile to red if it is a ship tile and black if not
    // if tile has already been called then nothing occurs
    public void SelectTile(String voiceInput)
    {       
          // Check if input is in the list of tiles
          for(int i = 0; i<6; i++)
          {
            for(int j = 0; j<6; j++)
            {
                if (voiceInput == tileList[i,j])
                {
                    if(board[i,j] == 1)
                    {
                        board[i, j] = 2;
                        shipPieces -= 1;
                        Transform pickedPiece = gameBoard.transform.Find(voiceInput);
                        pickedPiece.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    }
                    else if (board[i, j] == 0)
                    {
                        lives -= 1;
                        board[i, j] = 2;
                        Transform pickedPiece = gameBoard.transform.Find(voiceInput);
                        pickedPiece.gameObject.GetComponent<Renderer>().material.color = Color.black;
                    }
                }
            }
          }
    }

    // checks for win conditions and sets the gameWon value to true or false
    private void CheckWinConditions()
    {
        if (lives <= 0)
        {
            gameObject.GetComponent<UIManager>().gameWon = false;
            gameObject.GetComponent<UIManager>().GameEnd();
        }
        if(shipPieces <= 0)
        {
            gameObject.GetComponent<UIManager>().gameWon = true;
            gameObject.GetComponent<UIManager>().GameEnd();
        }
        
    }

    // Checks win conditions0   
    void Update()
    {
        CheckWinConditions();
    }
}

