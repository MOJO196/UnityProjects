using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeButtonClick : MonoBehaviour
{
    [SerializeField]
    private int buttonPosition;
    [SerializeField]
    private Image buttonImage;
    public void ButtonClick()
    {
        if (TicTacToeStats.buttonUsed[buttonPosition - 1] == 0 && TicTacToeStats.gameRunning && !TicTacToeStats.duringMove)
        {
            TicTacToeStats.duringMove = true;
            TicTacToeStats.moves++;

            if (TicTacToeStats.player1ToMove)
            {
                buttonImage.color = Color.blue;
                TicTacToeStats.buttonUsed[buttonPosition - 1] = 1;
                TicTacToeGame.instance.CheckGameState(1, true);
            }
            else
            {
                buttonImage.color = Color.red;
                TicTacToeStats.buttonUsed[buttonPosition - 1] = 2;
                TicTacToeGame.instance.CheckGameState(2, true);
            }

            TicTacToeStats.player1ToMove = !TicTacToeStats.player1ToMove;
            TicTacToeStats.duringMove = false;

            if (!(TicTacToeStats.AILevel == 0) && !TicTacToeStats.player1ToMove)
                TicTacToeButtonManager.instance.AIMove();
            else
               TicTacToePlayerToMove.instance.PlayerToMove();
        }
        else if (TicTacToeStats.duringRestart && !TicTacToeStats.gameRunning)
            buttonImage.color = Color.white;
    }
}
