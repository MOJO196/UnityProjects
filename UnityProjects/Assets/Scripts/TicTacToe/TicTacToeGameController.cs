using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGameController : MonoBehaviour
{
    bool canEnd = true;
    bool canRestart = true;
    public static TicTacToeGameController instance;
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        if (Random.value >= 0.5) TicTacToeStats.player1BeganToStart = true;
        else TicTacToeStats.player1BeganToStart = false;

        TicTacToeStats.player1ToMove = !TicTacToeStats.player1BeganToStart;
        TicTacToeStats.gameRunning = true;
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame() //Change soon if Menu Buttons improve
    {
        TicTacToeStats.player1BeganToStart = !TicTacToeStats.player1BeganToStart;
        TicTacToeStats.player1ToMove = TicTacToeStats.player1BeganToStart;

        TicTacToeStats.moves = 0;
        TicTacToePlayerToMove.instance.PlayerToMove();

        if (!TicTacToeStats.player1ToMove) TicTacToeButtonManager.instance.AIMove();
    }

    public void RestartGame()
    {
        if (!TicTacToeStats.gameRunning && canRestart)
        {
            if (TicTacToeStats.player1Score == TicTacToeStats.pointsNeedToWin || TicTacToeStats.player2Score == TicTacToeStats.pointsNeedToWin)
            {
                Debug.Log("EndGame by Reset "+TicTacToeStats.pointsNeedToWin);
                TicTacToeGameController.instance.EndGame();
                return;
            }

            TicTacToeStats.duringRestart = true;
            TicTacToeButtonManager.instance.ResetButtons();
            TicTacToeLineManager.instance.ResetLine();
            TicTacToeStats.gameRunning = true;
            StartGame();
            TicTacToeStats.duringRestart = false;
        }
    }

    public void EndGame()
    {
        if (canEnd)
        {
            canEnd = false;
            canRestart = false;
            SaveSystem.SaveTicTacToe();
            Debug.Log("Score " + TicTacToeStats.player1Score + ":" + TicTacToeStats.player2Score);
            SceneLoader.instance.NextScene();
        }
    }
}
