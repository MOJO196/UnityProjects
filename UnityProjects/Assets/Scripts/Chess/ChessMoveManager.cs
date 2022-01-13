using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMoveManager : MonoBehaviour
{
    int firstRow = -1, firstCol = -1, secondRow = -1, secondCol = -1, moveID;
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

    public void NewMove(int row, int col)
    {
        if (firstRow == -1)
        {
            firstRow = row;
            firstCol = col;
        }
        else
        {
            secondRow = row;
            secondCol = col;
        }

        if (firstRow != -1 && secondRow != -1)
        {
            ChessMove newMove = new ChessMove(firstRow, firstCol, secondRow, secondCol);
            moveID++;

            firstRow = -1;
            firstCol = -1;
            secondRow = -1;
            secondCol = -1;

            MakeMove(newMove);
            return;
        }
    }

    public void MakeMove(ChessMove move)
    {
        if ((ChessGame.piece)move.move[4] == ChessGame.piece.eS)
        {
            return;
        }
        else if (ChessStats.whiteToMove)
        {
            switch ((ChessGame.piece)move.move[4])
            {
                case ChessGame.piece.wP:
                    PawnMoves(move);
                    break;
                case ChessGame.piece.wR:
                    break;
                case ChessGame.piece.wN:
                    break;
                case ChessGame.piece.wB:
                    break;
                case ChessGame.piece.wQ:
                    break;
                case ChessGame.piece.wK:
                    break;
            }
        }
        else
        {
            switch ((ChessGame.piece)move.move[4])
            {
                case ChessGame.piece.bP:
                    PawnMoves(move);
                    break;
                case ChessGame.piece.bR:
                    break;
                case ChessGame.piece.bN:
                    break;
                case ChessGame.piece.bB:
                    break;
                case ChessGame.piece.bQ:
                    break;
                case ChessGame.piece.bK:
                    break;
            }
        }
    }

    int PawnMoves(ChessMove move)
    {
        if (ChessStats.gameState[(int)move.move[0], (int)move.move[1]] == ChessGame.piece.wP)
        {
            if (ChessStats.gameState[(int)move.move[0] - 1, (int)move.move[1]] == ChessGame.piece.eS)
            {
                if ((int)move.move[0] - 1 == (int)move.move[2])
                {
                    DoMove(move);
                    return 0;
                }
                else if (ChessStats.gameState[(int)move.move[0] - 2, (int)move.move[1]] == ChessGame.piece.eS)
                {
                    if ((int)move.move[0] == (int)move.move[2] - 2)
                    {
                        if ((int)move.move[0] == 6)
                        {
                            DoMove(move);
                            return 0;
                        }
                    }

                }
            }
        }
        else if (ChessStats.gameState[(int)move.move[0], (int)move.move[1]] == ChessGame.piece.bP)
        {
            if (ChessStats.gameState[(int)move.move[0] + 1, (int)move.move[1]] == ChessGame.piece.eS)
            {
                if ((int)move.move[0] - 1 == (int)move.move[2])
                {
                    DoMove(move);
                    return 0;
                }
                else if (ChessStats.gameState[(int)move.move[0] + 2, (int)move.move[1]] == ChessGame.piece.eS && (int)move.move[0] == (int)move.move[2] + 2 && (int)move.move[0] == 6)
                {
                    DoMove(move);
                    return 0;
                }
            }
        }
        else
        {
            ErrorMessages.instance.ChessError(1);
            return -1;
        }

        return -1;
    }

    void DoMove(ChessMove move)
    {
        ChessGridManager.instance.DrawTile((int)move.move[4], ChessStats.whiteToMove, (int)move.move[0], (int)move.move[1]);
        ChessGridManager.instance.DrawTile(0, ChessStats.whiteToMove, (int)move.move[2], (int)move.move[3]);
        moveLog.AddToMoves(move);
        ChessStats.whiteToMove = !ChessStats.whiteToMove;
    }
}
