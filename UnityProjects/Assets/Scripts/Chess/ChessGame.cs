using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    public static ChessGame instance;

    public enum piece
    {
        eS,
        wP,
        wR,
        wN,
        wB,
        wQ,
        wK,
        bP,
        bR,
        bN,
        bB,
        bQ,
        bK
    }

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        StartNewGame();
    }

    void StartNewGame()
    {
        StartPosition();
        ChessStats.whiteToMove = true;
        ChessStats.gameRunning = true;
        ChessGridManager.instance.CreateGrid();
    }

    void StartPosition()
    {
        ChessStats.gameState = new piece[ChessStats.row, ChessStats.col]
        {
            {piece.bR, piece.bN, piece.bB, piece.bQ, piece.bK, piece.bB, piece.bN, piece.bR},
            {piece.bP, piece.bP, piece.bP, piece.bP, piece.bP, piece.bP, piece.bP, piece.bP},
            {piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS},
            {piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS},
            {piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS},
            {piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS, piece.eS},
            {piece.wP, piece.wP, piece.wP, piece.wP, piece.wP, piece.wP, piece.wP, piece.wP},
            {piece.wR, piece.wN, piece.wB, piece.wQ, piece.wK, piece.wB, piece.wN, piece.wR}
        };
    }
}
