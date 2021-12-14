using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGameController : MonoBehaviour
{
    private bool canEnd = true;
    private bool canRestart = true;
    [SerializeField]
    private int AILevel;
    public static TicTacToeGameController instance;
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        if (Random.value >= 0.5)
            TicTacToeStats.player1BeganToStart = true;
        else
            TicTacToeStats.player1BeganToStart = false;

        TicTacToeStats.player1ToMove = !TicTacToeStats.player1BeganToStart;
        TicTacToeStats.gameRunning = true;
        TicTacToeStats.AILevel = AILevel;
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
        if (!TicTacToeStats.player1ToMove)
            TicTacToeButtonManager.instance.AIMove();
    }

    public void RestartGame()
    {
        if (!TicTacToeStats.gameRunning && canRestart)
        {
            TicTacToeStats.duringRestart = true;
            ResetButtonUsed();
            TicTacToeStats.gameRunning = true;
            TicTacToeStats.AILevel = AILevel;
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
            Debug.Log("Score " + TicTacToeStats.player1Score + ":" + TicTacToeStats.player2Score);
            SceneLoader.instance.NextScene();
        }
    }

    private void ResetButtonUsed()
    {
        for (int i = 0; i < 9; i++)
        {
            TicTacToeStats.buttonUsed[i] = 0;
            TicTacToeButtonManager.instance.Move(i);
        }
    }
}
