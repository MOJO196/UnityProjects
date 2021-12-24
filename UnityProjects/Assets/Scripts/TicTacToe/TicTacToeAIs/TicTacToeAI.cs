using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI", menuName = "TicTacToeAIs/AI")]
public class TicTacToeAI : ScriptableObject
{
    public int maxMoves;
    public virtual int NextMove()
    {
        return -1;
    }
}
