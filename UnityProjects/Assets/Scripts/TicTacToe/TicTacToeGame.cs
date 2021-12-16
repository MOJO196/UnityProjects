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

    public int CheckGameState(int player, bool getWinner)
    {
        int winningMove;
        //Rows   
        if (TicTacToeStats.buttonUsed[0] == player && TicTacToeStats.buttonUsed[1] == player && TicTacToeStats.buttonUsed[2] == player)
            winningMove = 1;
        else if (TicTacToeStats.buttonUsed[3] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[5] == player)
            winningMove = 2;
        else if (TicTacToeStats.buttonUsed[6] == player && TicTacToeStats.buttonUsed[7] == player && TicTacToeStats.buttonUsed[8] == player)
            winningMove = 3;
        //Columns
        else if (TicTacToeStats.buttonUsed[0] == player && TicTacToeStats.buttonUsed[3] == player && TicTacToeStats.buttonUsed[6] == player)
            winningMove = 4;
        else if (TicTacToeStats.buttonUsed[1] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[7] == player)
            winningMove = 5;
        else if (TicTacToeStats.buttonUsed[2] == player && TicTacToeStats.buttonUsed[5] == player && TicTacToeStats.buttonUsed[8] == player)
            winningMove = 6;
        //Diagonals
        else if (TicTacToeStats.buttonUsed[0] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[8] == player)
            winningMove = 7;
        else if (TicTacToeStats.buttonUsed[2] == player && TicTacToeStats.buttonUsed[4] == player && TicTacToeStats.buttonUsed[6] == player)
            winningMove = 8;
        else
            winningMove = 0;

        if (winningMove == 0)
        {
            //Nobody wins
            if (TicTacToeStats.moves == 9 && getWinner)
                Draw();
        }
        else
            if (getWinner)
            {
                
                switch (winningMove)
                {
                    case 1:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[0], TicTacToeButtonManager.instance.buttons[2]);
                        TicTacToeDrawLine2.instance.DrawLine(TicTacToeButtonManager.instance.buttons[3], TicTacToeButtonManager.instance.buttons[2]);
                        break;
                    case 2:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[3], TicTacToeButtonManager.instance.buttons[5]);
                        break;
                    case 3:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[6], TicTacToeButtonManager.instance.buttons[8]);
                        break;
                    case 4:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[0], TicTacToeButtonManager.instance.buttons[6]);
                        break;
                    case 5:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[1], TicTacToeButtonManager.instance.buttons[7]);
                        break;
                    case 6:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[2], TicTacToeButtonManager.instance.buttons[8]);
                        break;
                    case 7:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[0], TicTacToeButtonManager.instance.buttons[8]);
                        break;
                    case 8:
                        TicTacToeDrawLine1.instance.DrawLine(TicTacToeButtonManager.instance.buttons[2], TicTacToeButtonManager.instance.buttons[6]);
                        break;
                } 
                
                PlayerWon(player);
            }
        return winningMove;
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
        if (TicTacToeStats.player1Score == TicTacToeStats.pointsNeedToWin || TicTacToeStats.player2Score == TicTacToeStats.pointsNeedToWin)
            TicTacToeGameController.instance.EndGame();
        else if (TicTacToeStats.player1Score == TicTacToeStats.pointsNeedToWin-1 || TicTacToeStats.player2Score == TicTacToeStats.pointsNeedToWin-1)
            TicTacToeStats.matchpoint = true; //Matchpoint overlay
    }
}
