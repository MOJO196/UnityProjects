using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGameController : MonoBehaviour
{
    private bool canEnd = true;
    private bool canReset = true;
    public bool randomPlayerToBeginn;
    public bool player1ToBeginn;
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

    public void StartGame()
    {
        if (Random.value >= 0.5 && randomPlayerToBeginn)
            TicTacToeStats.player1ToMove = true;
        else if (!randomPlayerToBeginn)
            TicTacToeStats.player1ToMove = player1ToBeginn;
        else
            TicTacToeStats.player1ToMove = false;

        TicTacToeStats.moves = 0;
        TicTacToeStats.gameRunning = true;
        TicTacToeStats.AILevel = AILevel;
        TicTacToePlayerToMove.instance.PlayerToMove();
        TicTacToeButtonManager.instance.AIMove();
    }

    public void ResetGame()
    {
        if (!TicTacToeStats.gameRunning && canReset)
        {
            ResetButtonsUsed();
            TicTacToeGameController.instance.StartGame();
        }
    }

    public void EndGame()
    {
        if (canEnd)
        {
            canEnd = false;
            canReset = false;
            Debug.Log("Score " + TicTacToeStats.player1Score + ":" + TicTacToeStats.player2Score);
            SceneLoader.instance.NextScene();
        }
    }

    private void ResetButtonsUsed()
    {
        for (int i = 0; i < 9; i++)
        {
            TicTacToeStats.buttonUsed[i] = 0;
            TicTacToeButtonManager.instance.Move(i);
        }
    }
}
