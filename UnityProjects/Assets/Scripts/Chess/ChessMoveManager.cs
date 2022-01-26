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
        //DoMove(move);

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
        else if (!ChessStats.whiteToMove)
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
            if ((int)move.move[1] == (int)move.move[3]) //move forwards
            {
                if (ChessStats.gameState[(int)move.move[0] - 1, (int)move.move[1]] == ChessGame.piece.eS)
                {
                    if ((int)move.move[0] - 1 == (int)move.move[2])
                    {
                        if ((int)move.move[0] - 1 == 0) //promotion
                        {
                            Debug.Log("Promotion!");
                        }

                        DoMove(move);
                        return 0;
                    }
                    else if (ChessStats.gameState[(int)move.move[0] - 2, (int)move.move[1]] == ChessGame.piece.eS && (int)move.move[0] == 6 && (int)move.move[0] - 2 == (int)move.move[2])
                    {
                        DoMove(move);
                        return 0;
                    }
                }
            }
            else if ((int)move.move[0] - 1 == (int)move.move[2] && (int)move.move[1] - 1 == (int)move.move[3]) //capture left
            {
                for (int i = 0; i < 7; i++)
                {
                    if (ChessStats.gameState[(int)move.move[0] - 1, (int)move.move[1] - 1] == ChessGame.piece.eS + i)
                    {
                        return -1;
                    }

                    if ((int)move.move[0] - 1 == 1) PawnPromotion(); //promotion
                    DoMove(move);
                }
            }
            else if ((int)move.move[0] - 1 == (int)move.move[2] && (int)move.move[1] + 1 == (int)move.move[3]) //capture right
            {
                for (int i = 0; i < 7; i++)
                {
                    if (ChessStats.gameState[(int)move.move[0] - 1, (int)move.move[1] + 1] == ChessGame.piece.eS + i)
                    {
                        return -1;
                    }

                    if ((int)move.move[0] - 1 == 1) PawnPromotion(); //promotion
                    DoMove(move);
                }
            }
            else if (false) //en passent
            {

            }
            else if (false) //castling
            {

            }
        }
        else if (ChessStats.gameState[(int)move.move[0], (int)move.move[1]] == ChessGame.piece.bP)
        {
            if ((int)move.move[1] == (int)move.move[3]) //move forwards
            {
                if (ChessStats.gameState[(int)move.move[0] + 1, (int)move.move[1]] == ChessGame.piece.eS)
                {
                    if ((int)move.move[0] + 1 == (int)move.move[2])
                    {
                        if ((int)move.move[0] + 1 == 7) PawnPromotion(); //promotion

                        DoMove(move);
                        return 0;
                    }
                    else if (ChessStats.gameState[(int)move.move[0] + 2, (int)move.move[1]] == ChessGame.piece.eS && (int)move.move[0] == 1 && (int)move.move[0] + 2 == (int)move.move[2])
                    {
                        DoMove(move);
                        return 0;
                    }
                }
            }
            else if ((int)move.move[0] + 1 == (int)move.move[2] && (int)move.move[1] - 1 == (int)move.move[3]) //capture left
            {
                for (int i = 0; i < 7; i++)
                {
                    if (ChessStats.gameState[(int)move.move[0] + 1, (int)move.move[1] - 1] == ChessGame.piece.eS + i)
                    {
                        return -1;
                    }

                    if ((int)move.move[0] + 1 == 1) PawnPromotion(); //promotion
                    DoMove(move);
                }
            }
            else if ((int)move.move[0] + 1 == (int)move.move[2] && (int)move.move[1] + 1 == (int)move.move[3]) //capture right
            {
                for (int i = 0; i < 7; i++)
                {
                    if (ChessStats.gameState[(int)move.move[0] + 1, (int)move.move[1] + 1] == ChessGame.piece.eS + i)
                    {
                        return -1;
                    }

                    if ((int)move.move[0] + 1 == 1) PawnPromotion(); //promotion
                    DoMove(move);
                }
            }
            else if (false) //en passent
            {

            }
            else if (false) //castling
            {

            }
        }

        return -1;
    }

    int RookMoves()
    {
        
    }

    void PawnPromotion()
    {
        Debug.Log("Promotion!");
    }

    void DoMove(ChessMove move)
    {
        ChessGridManager.instance.DrawTile(0, (int)move.move[2], (int)move.move[3]);
        ChessGridManager.instance.DrawTile((int)move.move[4], (int)move.move[2], (int)move.move[3]);
        ChessGridManager.instance.DrawTile(0, (int)move.move[0], (int)move.move[1]);

        ChessStats.gameState[(int)move.move[2], (int)move.move[3]] = (ChessGame.piece)move.move[4];
        ChessStats.gameState[(int)move.move[0], (int)move.move[1]] = ChessGame.piece.eS;

        moveLog.AddToMoves(move);
        ChessStats.whiteToMove = !ChessStats.whiteToMove;
    }
}
