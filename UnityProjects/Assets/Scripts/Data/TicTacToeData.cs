using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TicTacToeData
{
    public int AILevel;
    public string time;
    public int score; //-3 => Enemy won by 3 points difference
    public int[]gameState;

    public void UpdateTicTacToeData()
    {
        AILevel = TicTacToeStats.AILevel;
        time = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        score = TicTacToeStats.player1Score-TicTacToeStats.player2Score;
        gameState = TicTacToeStats.buttonUsed;
    }
}
