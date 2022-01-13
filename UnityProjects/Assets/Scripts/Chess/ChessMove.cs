using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChessMove
{
    public object[] move;

    ChessMove(int firstRow, int firstCol, int secondRow, int secondCol)
    {
        move = new object[6]
        {
            firstRow,
            firstCol,
            secondRow,
            secondCol,
            ChessStats.gameState[firstRow, firstCol],
            ChessStats.gameState[secondRow, secondCol]
        };
    }
}
