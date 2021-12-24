using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "AILevel4", menuName = "TicTacToeAIs/AILevel4")]
public class TicTacToeAILevel4 : TicTacToeAI
{
    public override int NextMove()
    {
        base.maxMoves = 7;
        if (TicTacToeStats.moves >= base.maxMoves) return -1;

        int result = -1;
        int[] wins = new int[9];

        for (int i = 0; i < 9; i++)
        {
            if (TicTacToeStats.buttonUsed[i] == 0)
            {
                TicTacToeStats.buttonUsed[i] = 2;

                for (int j = 0; j < 9; j++)
                {
                    if (TicTacToeStats.buttonUsed[j] == 0)
                    {
                        TicTacToeStats.buttonUsed[j] = 1;

                        for (int k = 0; k < 9; k++)
                        {
                            if (TicTacToeStats.buttonUsed[k] == 0)
                            {
                                TicTacToeStats.buttonUsed[k] = 2;
                                result = TicTacToeGame.instance.CheckGameState(2, false);
                                TicTacToeStats.buttonUsed[k] = 0;

                                if (result != -1) wins[i]++;
                            }
                        }
                        TicTacToeStats.buttonUsed[j] = 0;
                    }
                }
                TicTacToeStats.buttonUsed[i] = 0;
            }
            else wins[i] = 0;
            if (wins[i] >= 2) return wins.ToList().IndexOf(wins.Max()); //Faster
        }
        result = wins.ToList().IndexOf(wins.Max()); //Randomize here to prevent same game results
        if (result == 0) return -1;
        else return result;
    }
}
