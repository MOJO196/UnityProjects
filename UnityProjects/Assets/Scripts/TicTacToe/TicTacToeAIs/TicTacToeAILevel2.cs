﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AILevel2", menuName = "TicTacToeAIs/AILevel2")]
public class TicTacToeAILevel2 : TicTacToeAI
{
    public override int nextMove()
    {
        int result = -1;

        for (int i = 0; i < 9; i++)
        {
            if (TicTacToeStats.buttonUsed[i] == 0)
            {
                TicTacToeStats.buttonUsed[i] = 2;
                result = TicTacToeGame.instance.CheckGameState(2, false);
                TicTacToeStats.buttonUsed[i] = 0;

                if (result != -1) return i;
            }
            if (result == -1 && i == 8)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (TicTacToeStats.buttonUsed[j] == 0)
                    {
                        TicTacToeStats.buttonUsed[j] = 1;
                        result = TicTacToeGame.instance.CheckGameState(1, false);
                        TicTacToeStats.buttonUsed[j] = 0;

                        if (result != -1) return j;
                    }
                    if (result == -1 && j == 8)
                    {
                        for (; ; )
                        {
                            int move = Random.Range(0, 9);

                            if (TicTacToeStats.buttonUsed[move] == 0) return move;
                        }
                    }
                }
            }
        }
        return base.nextMove();
    }
}
