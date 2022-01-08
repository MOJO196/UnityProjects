using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    [SerializeField]
    private int row;
    [SerializeField]
    private int col;
    [SerializeField]
    private float tileSize;
    public static SnakeGame instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        SnakeStats.row = row;
        SnakeStats.col = col;
        SnakeStats.tileSize = tileSize;
        SnakeStats.gameState = new int[SnakeStats.row, SnakeStats.col];
    }

    void Start()
    {
        CreateNewGame();
    }

    void SatrtingPosition()
    {
        int startingRow = Random.Range(0, SnakeStats.row);
        int startingCol = Random.Range(0, SnakeStats.col);
        UpdatePlayerPosition(startingRow, startingCol);
    }

    public void CreateNewGame()
    {
        SnakeGridManager.instance.CreateGrid();
        SatrtingPosition();
        SummonFruit();
        SnakeStats.gameRunning = true;
    }

    public void SummonFruit()
    {
        SnakeStats.score++;

        for (; ; )
        {
            int fruitRow = Random.Range(0, SnakeStats.row);
            int fruitCol = Random.Range(0, SnakeStats.col);

            if (SnakeStats.gameState[fruitRow, fruitCol] == 0)
            {
                SnakeStats.gameState[fruitRow, fruitCol] = -1;
                SnakeGridManager.instance.CreateTile(fruitRow, fruitCol, -1);
                Debug.Log(fruitRow + ", " + fruitCol);
                return;
            }
        }
    }

    public void GameOver()
    {
        SnakeStats.gameRunning = false;
    }

    public void UpdatePlayerPosition(int row, int col)
    {
        SnakeStats.playerPos[0] = row;
        SnakeStats.playerPos[1] = col;
        SnakeStats.gameState[row, col] = 1;
        SnakeGridManager.instance.CreateTile(row, col, 1);
    }
}
