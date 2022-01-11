using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeScore : Score
{
    [SerializeField]
    GameObject scoreObj;

    void Awake()
    {
        SetScore();
    }

    protected override void SetScore()
    {
        scoreObj.GetComponentInChildren<Text>().text = "Score : " + TicTacToeStats.player1Score.ToString() + " - " + TicTacToeStats.player2Score.ToString();
    }
}
