using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeButtonClick : MonoBehaviour
{
    public int buttonPosition;
    public Image buttonImage;
    public void ButtonClick()
    {
        if (TicTacToeStats.buttonUsed[buttonPosition - 1] == 0 && TicTacToeStats.gameRunning)
        {
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

            if (TicTacToeStats.computer && !TicTacToeStats.player1ToMove)
                TicTacToeButtonManager.instance.ComputerMove();
            else
                TicTacToePlayerToMove.instance.PlayerToMove();
        }
        else if (TicTacToeStats.buttonUsed[buttonPosition - 1] == 0 && !TicTacToeStats.gameRunning)
        {
            buttonImage.color = Color.white;
        }
    }
}
