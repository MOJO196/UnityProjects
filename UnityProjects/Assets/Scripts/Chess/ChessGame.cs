using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    public static ChessGame instance;

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
        ChessStats.gameState = new string[ChessStats.row, ChessStats.col]
        {
            {"BR", "BN", "BB", "BK", "BQ", "BB", "BN", "BR"},
            {"BP", "BP", "BP", "BP", "BP", "BP", "BP", "BP"},
            {"--", "--", "--", "--", "--", "--", "--", "--"},
            {"--", "--", "--", "--", "--", "--", "--", "--"},
            {"--", "--", "--", "--", "--", "--", "--", "--"},
            {"--", "--", "--", "--", "--", "--", "--", "--"},
            {"WP", "WP", "WP", "WP", "WP", "WP", "WP", "WP"},
            {"WR", "WN", "WB", "WK", "WQ", "WB", "WN", "WR"}
        };
    }
}
