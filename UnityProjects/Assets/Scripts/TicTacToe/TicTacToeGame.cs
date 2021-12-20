using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGame : MonoBehaviour
{
    public int[][] possibleWins;
    public static TicTacToeGame instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        possibleWins = new int[][]{
            //Rows
            new int[]{0,1,2},
            new int[]{3,4,5},
            new int[]{6,7,8},
            //Columns
            new int[]{0,3,6},
            new int[]{1,4,7},
            new int[]{2,5,8},
            //Diagonals
            new int[]{0,4,8},
            new int[]{2,4,6}
        };
    }

    public int CheckGameState(int player, bool getWinner)
    {
        int[] winningMoves = new int[2];

        for (int i = 0; i < possibleWins.Length; i++)
        {
            bool winning = true;

            for (int j = 0; j < 3; j++)
            {
                if (TicTacToeStats.buttonUsed[possibleWins[i][j]] != player)
                    winning = false;
            }

            if (winning)
                if (winningMoves[0] == 0)
                    winningMoves[0] = i + 1;
                else
                    winningMoves[1] = i + 1;
        }

        if (winningMoves[0] == 0)
        {
            if (TicTacToeStats.moves == 9 && getWinner)
                Draw();
            return 0;
        }
        else
        {
            if (getWinner)
            {
                for (int i = 0; i < winningMoves.Length; i++)
                {
                    switch (winningMoves[i])
                    {
                        case 1:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[0], TicTacToeButtonManager.instance.buttons[2]);
                            break;
                        case 2:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[3], TicTacToeButtonManager.instance.buttons[5]);
                            break;
                        case 3:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[6], TicTacToeButtonManager.instance.buttons[8]);
                            break;
                        case 4:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[0], TicTacToeButtonManager.instance.buttons[6]);
                            break;
                        case 5:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[1], TicTacToeButtonManager.instance.buttons[7]);
                            break;
                        case 6:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[2], TicTacToeButtonManager.instance.buttons[8]);
                            break;
                        case 7:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[0], TicTacToeButtonManager.instance.buttons[8]);
                            break;
                        case 8:
                            TicTacToeLineManager.instance.DrawLine(i, TicTacToeButtonManager.instance.buttons[2], TicTacToeButtonManager.instance.buttons[6]);
                            break;
                    }
                }
                PlayerWon(player);
            }
            return winningMoves[0];
        }
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
        else if (TicTacToeStats.player1Score == TicTacToeStats.pointsNeedToWin - 1 || TicTacToeStats.player2Score == TicTacToeStats.pointsNeedToWin - 1)
            TicTacToeStats.matchpoint = true; //Matchpoint overlay
    }
}
