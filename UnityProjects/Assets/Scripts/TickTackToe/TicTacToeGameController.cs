using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeGameController : MonoBehaviour
{
    public static bool randomPlayerToBeginn;
    public static bool player1ToBeginn;
    public static bool againstComputer;
    public static int AILevel;
    public static float timer;
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
        TicTacToeStats.computer = againstComputer;
        TicTacToeStats.AILevel = AILevel;
        TicTacToePlayerToMove.instance.PlayerToMove();
        TicTacToeButtonManager.instance.ComputerMove();
    }

    public void ResetButton()
    {
        if (!TicTacToeStats.gameRunning)
        {
            ResetButtonsUsed();
            TicTacToeGameController.instance.StartGame();
        }
    }

    public void EndGame()
    {
        timer = Time.time;
        Debug.Log("--- Result ---\n" + "Player 1 : " + TicTacToeStats.player1Score + "\nPlayer 2 :" + TicTacToeStats.player2Score);
        //SceneLoader.instance.NextScene();
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
