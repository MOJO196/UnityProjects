using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AILevel1", menuName = "TicTacToeAIs/AILevel1")]
public class TicTacToeAILevel1 : TicTacToeAI
{
    public override int NextMove()
    {
        Debug.Log("AI1");
        
        for (; ; )
        {
            int move = Random.Range(0, 9);

            if (TicTacToeStats.buttonUsed[move] == 0) return move;
        }
    }
}