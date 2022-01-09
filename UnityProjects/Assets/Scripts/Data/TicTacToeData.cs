using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TicTacToeData
{
    bool resetData = false; //set true to reset all data
    public object[,] score; //[AILevel, player1Score, player2Score, time]

    public TicTacToeData()
    {
        if (SaveSystem.LoadTicTacToe() != null && !resetData)
        {
            TicTacToeData oldData = SaveSystem.LoadTicTacToe();
            score = oldData.score;
        }
        else
        {
            score = new object[6,4]
            {
                {0, 0, 0, null},
                {1, 0, 0, null},
                {2, 0, 0, null},
                {3, 0, 0, null},
                {4, 0, 0, null},
                {5, 0, 0, null}
            };
        }

        score[TicTacToeStats.AILevel, 1] = TicTacToeStats.player1Score + (int) score[TicTacToeStats.AILevel, 1];
        score[TicTacToeStats.AILevel, 2] = TicTacToeStats.player2Score + (int) score[TicTacToeStats.AILevel, 2];
        score[TicTacToeStats.AILevel, 3] = System.DateTime.Now.ToString("dd/MM/ HH:mm:ss");
    }
}
