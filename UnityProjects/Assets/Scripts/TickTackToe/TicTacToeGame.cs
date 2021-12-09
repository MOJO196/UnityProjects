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

        DontDestroyOnLoad(this.gameObject);
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
        TicTacToeStats.draw = true;
        TicTacToeStats.gameRunning = false;
        TicTacToeStats.player1Score += 0.5f;
        TicTacToeStats.player2Score += 0.5f;
    }

    public void PlayerWon(int player)
    {
        switch (player)
        {
            case 1:
                TicTacToeStats.player1Won = true;
                TicTacToeStats.player1Score++;
                Debug.Log("Player " + player + " won!");
                break;
            case 2:
                TicTacToeStats.player2Won = true;
                TicTacToeStats.player2Score++;
                if (TicTacToeStats.computer)
                    Debug.Log("Computer won!");
                else
                    Debug.Log("Player " + player + " won!");
                break;
        }
        TicTacToeStats.gameRunning = false;
    }
}
