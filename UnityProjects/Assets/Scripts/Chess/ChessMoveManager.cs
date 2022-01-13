using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMoveManager : MonoBehaviour
{
    public ChessMoves moveLog;
    public static ChessMoveManager instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        moveLog = new ChessMoves();
    }

    public void MakeMove(ChessMove move)
    {
        if ((string)move.move[4] == "--")
        {
            return;
        }
        else if (ChessStats.whiteToMove)
        {
            if ((string)move.move[4] == "WP")
            {

            }
            else if ((string)move.move[4] == "WR")
            {

            }
            else if ((string)move.move[4] == "WN")
            {

            }
            else if ((string)move.move[4] == "WB")
            {

            }
            else if ((string)move.move[4] == "WQ")
            {

            }
            else if ((string)move.move[4] == "WK")
            {

            }
        }
        else
        {
            if ((string)move.move[4] == "BP")
            {

            }
            else if ((string)move.move[4] == "BR")
            {

            }
            else if ((string)move.move[4] == "BN")
            {

            }
            else if ((string)move.move[4] == "BB")
            {

            }
            else if ((string)move.move[4] == "BQ")
            {

            }
            else if ((string)move.move[4] == "BK")
            {

            }
        }
    }

    int PawnMoves(int firstRow, int firstCol, int secondRow, int secondCol)
    {
        if (ChessStats.gameState[firstRow, firstCol] == "WP")
        {
            if (ChessStats.gameState[firstRow - 1, firstCol] == "--")
            {
                if (firstRow == secondRow - 1)
                {

                }
                else if (ChessStats.gameState[firstRow - 2, firstCol] == "--" && firstRow == secondRow - 2 && firstRow == 6)
                {

                }
            }
        }
        else if (ChessStats.gameState[firstRow, firstCol] == "BP")
        {

        }
        else
        {
            ErrorMessages.instance.ChessError(1);
            return -1;
        }

        return 0;
    }

    void DoMove(ChessMove move)
    {
        ChessStats.whiteToMove = !ChessStats.whiteToMove;
    }
}
