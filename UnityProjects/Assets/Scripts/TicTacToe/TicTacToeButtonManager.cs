using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeButtonManager : MonoBehaviour
{
    public Button[] buttons = new Button[9];
    public TicTacToeAI[] AIs = new TicTacToeAI[5];
    public static TicTacToeButtonManager instance;
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        AIMove();
    }

    public void AIMove()
    {
        if (TicTacToeStats.gameRunning && !TicTacToeStats.player1ToMove && TicTacToeStats.AILevel != 0)
        {
            //Debug.Log(TicTacToeStats.moves + ", " + TicTacToeStats.AILevel); //Debug AI Moves

            if (TicTacToeStats.moves == 0)
            {
                Move(4);
                return;
            }

            int nextAIMove = -1;

            switch (TicTacToeStats.AILevel)
            {
                case 1:
                    nextAIMove = AIs[0].NextMove();
                    break;
                case 2:
                    nextAIMove = AIs[1].NextMove();
                    if (nextAIMove == -1) nextAIMove = AIs[0].NextMove();
                    break;
                case 3:
                    nextAIMove = AIs[1].NextMove();
                    if (nextAIMove == -1) nextAIMove = AIs[2].NextMove();
                    if (nextAIMove == -1) nextAIMove = AIs[0].NextMove();
                    break;
                case 4:
                    nextAIMove = AIs[1].NextMove();
                    if (nextAIMove == -1) nextAIMove = AIs[3].NextMove();
                    if (nextAIMove == -1) nextAIMove = AIs[0].NextMove();
                    break;
            }
            Move(nextAIMove);
        }
    }

    public void ResetButtons()
    {
        for (int i = 0; i < 9; i++)
        {
            TicTacToeStats.buttonUsed[i] = 0;
            Move(i);
        }
    }

    void Move(int movePos)
    {
        buttons[movePos].Select();
        buttons[movePos].onClick.Invoke();
    }
}
