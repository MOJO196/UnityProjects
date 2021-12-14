using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    public static TicTacToeGame instance;
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        //TicTacToeDrawLine.instance.DrawLine(TicTacToeButtonManager.instance.buttons[1], TicTacToeButtonManager.instance.buttons[2]);    //csharp(CS0120)
    }

    public int CheckGameState(int player, bool getWinner)
    {
        int winningRow;
        //Rows   
        if (TicTacToeStats.buttonUsed[0] == player && TicTacToeStats.buttonUsed[1] == player && TicTacToeStats.buttonUsed[2] == player)
            winningRow = 1;
        else if (TicTacToeStats.buttonUsed[3] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[5] == player)
            winningRow = 2;
        else if (TicTacToeStats.buttonUsed[6] == player && TicTacToeStats.buttonUsed[7] == player && TicTacToeStats.buttonUsed[8] == player)
            winningRow = 3;
        //Columns
        else if (TicTacToeStats.buttonUsed[0] == player && TicTacToeStats.buttonUsed[3] == player && TicTacToeStats.buttonUsed[6] == player)
            winningRow = 4;
        else if (TicTacToeStats.buttonUsed[1] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[7] == player)
            winningRow = 5;
        else if (TicTacToeStats.buttonUsed[2] == player && TicTacToeStats.buttonUsed[5] == player && TicTacToeStats.buttonUsed[8] == player)
            winningRow = 6;
        //Diagonals
        else if (TicTacToeStats.buttonUsed[0] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[8] == player)
            winningRow = 7;
        else if (TicTacToeStats.buttonUsed[2] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[6] == player)
            winningRow = 8;
        else
            winningRow = 0;

        if (winningRow == 0)
        {
            //Nobody wins
            if (TicTacToeStats.moves == 9 && getWinner)
                Draw();
        }
        else
            if (getWinner)
                PlayerWon(player);
        return winningRow;
    }

    public void Draw()
    {
        Debug.Log("Draw");
        TicTacToeStats.gameRunning = false;
        //Draw overlay
    }

    public void PlayerWon(int player)
    {
        switch (player)
        {
            case 1:
                TicTacToeStats.player1Score++;
                Debug.Log("Player " + player + " won!");    //Player1 won overlay
                break;
            case 2:
                TicTacToeStats.player2Score++;
                if (!(TicTacToeStats.AILevel == 0))
                    Debug.Log("AI won!");   //AI won Overlay
                else
                    Debug.Log("Player " + player + " won!");    //Player2 won overlay
                break;
        }

        TicTacToeStats.gameRunning = false;
        Result();
    }

    public void Result()
    {
        if (TicTacToeStats.player1Score == 5 || TicTacToeStats.player2Score == 5)
            TicTacToeGameController.instance.EndGame();
        else if (TicTacToeStats.player1Score == 4 || TicTacToeStats.player2Score == 5)
            TicTacToeStats.matchpoint = true; //Matchpoint overlay
    }
}
