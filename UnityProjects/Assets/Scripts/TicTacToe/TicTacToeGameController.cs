using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGameController : MonoBehaviour
{
    private bool canEnd = true;
    private bool canRestart = true;
    public bool randomPlayerToBegin;
    public bool player1ToBegin;
    public int AILevel;
    public static TicTacToeGameController instance;
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
        StartGame();
    }

    public void StartGame() //Change soon if Menu Buttons improve
    {
        if (Random.value >= 0.5 && randomPlayerToBegin)
            TicTacToeStats.player1ToMove = true;
        else if (!randomPlayerToBegin)
            TicTacToeStats.player1ToMove = player1ToBegin;
        else
            TicTacToeStats.player1ToMove = false;

        TicTacToeStats.moves = 0;
        TicTacToeStats.gameRunning = true;
        TicTacToeStats.AILevel = AILevel;
        TicTacToePlayerToMove.instance.PlayerToMove();
        TicTacToeButtonManager.instance.AIMove();
    }

    public void RestartGame()
    {
        if (!TicTacToeStats.gameRunning && canRestart)
        {
            RestartButtonsUsed();
            TicTacToeGameController.instance.StartGame();
        }
    }

    public void EndGame()
    {
        if (canEnd)
        {
            canEnd = false;
            canRestart = false;
            Debug.Log("Score " + TicTacToeStats.player1Score + ":" + TicTacToeStats.player2Score);
            SceneLoader.instance.NextScene();
        }
    }

    private void RestartButtonsUsed()
    {
        for (int i = 0; i < 9; i++)
        {
            TicTacToeStats.buttonUsed[i] = 0;
            TicTacToeButtonManager.instance.Move(i);
        }
    }
}
