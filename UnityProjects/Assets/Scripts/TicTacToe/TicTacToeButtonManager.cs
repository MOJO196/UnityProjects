using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeButtonManager : MonoBehaviour
{
    public Button[] buttons = new Button[9];
    public TicTacToeAI[] AIs = new TicTacToeAI[3];
    public static TicTacToeButtonManager instance;
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        AIMove();
    }

    public void AIMove()
    {
        if (TicTacToeStats.gameRunning && !TicTacToeStats.player1ToMove)
        {
            if (TicTacToeStats.AILevel == 0) return;
            int nextAIMove = AIs[TicTacToeStats.AILevel - 1].nextMove();

            if (nextAIMove != -1 || nextAIMove > 8)
            {
                buttons[nextAIMove].Select();
                buttons[nextAIMove].onClick.Invoke();
            }
            else Debug.Log("ERROR");
        }
    }

    public void ResetButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            TicTacToeStats.buttonUsed[i] = 0;
            buttons[i].Select();
            buttons[i].onClick.Invoke();
        }
    }
}
