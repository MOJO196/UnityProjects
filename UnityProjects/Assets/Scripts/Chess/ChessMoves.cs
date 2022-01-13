using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChessMoves
{
    public ChessMoves[] moves;
    int moveID;

    public void AddToMoves(ChessMoves move)
    {
        moves[moveID] = move;
        moveID++;
    }

    public void DeleteMove() //undo move
    {
        moveID--;
        moves[moveID] = null;
    }
}

