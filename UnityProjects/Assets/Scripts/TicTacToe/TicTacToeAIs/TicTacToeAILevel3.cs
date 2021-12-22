using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AILevel3", menuName = "TicTacToeAIs/AILevel3")]
public class TicTacToeAILevel3 : TicTacToeAI
{
    public override int NextMove()
    {
        Debug.Log("AI3");
        int result = -1;

        for (int i = 0; i < 9; i++) //Check AI wins
        {
            if (TicTacToeStats.buttonUsed[i] == 0)
            {
                TicTacToeStats.buttonUsed[i] = 1;

                for (int j = 0; j < 9; j++)
                {
                    if (TicTacToeStats.buttonUsed[i] == 0)
                    {
                        TicTacToeStats.buttonUsed[j] = 1;
                        result = TicTacToeGame.instance.CheckGameState(1, false);
                        TicTacToeStats.buttonUsed[i] = 0;

                        if (result != -1)
                        {
                            TicTacToeStats.buttonUsed[i] = 0;
                            return i;
                        }
                    }
                }
                TicTacToeStats.buttonUsed[i] = 0;
            }
        }

        for (int i = 0; i < 9; i++) //Check player wins
        {
            if (TicTacToeStats.buttonUsed[i] == 0)
            {
                TicTacToeStats.buttonUsed[i] = 2;

                for (int j = 0; j < 9; j++)
                {
                    if (TicTacToeStats.buttonUsed[i] == 0)
                    {
                        TicTacToeStats.buttonUsed[j] = 2;
                        result = TicTacToeGame.instance.CheckGameState(2, false);
                        TicTacToeStats.buttonUsed[i] = 0;

                        if (result != -1)
                        {
                            TicTacToeStats.buttonUsed[i] = 0;
                            return i;
                        }
                    }
                }
                TicTacToeStats.buttonUsed[i] = 0;
            }
        }

        return base.NextMove();
    }
}
