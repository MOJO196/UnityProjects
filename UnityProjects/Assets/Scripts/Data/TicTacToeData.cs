using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TicTacToeData
{
    private bool resetData; //set true to reset all data
    public string lastTimePlayed;
    public int[,] score = new int[6, 3]; //[AILevel, player1Score, player2Score]

    public TicTacToeData()
    {
        if (SaveSystem.LoadTicTacToe() != null && !resetData)
        {
            TicTacToeData oldData = SaveSystem.LoadTicTacToe();
            score = oldData.score;
        }

        score[TicTacToeStats.AILevel, 1] += TicTacToeStats.player1Score;
        score[TicTacToeStats.AILevel, 2] += TicTacToeStats.player2Score;

        lastTimePlayed = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }
}
