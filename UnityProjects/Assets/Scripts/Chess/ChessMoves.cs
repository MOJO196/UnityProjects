using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChessMoves
{
    public ChessMove[] moves;
    int moveID;

    public ChessMoves()
    {
        moves = new ChessMove[500];
    }

    public void AddToMoves(ChessMove move)
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

