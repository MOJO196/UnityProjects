using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    [SerializeField]
    int row, col;
    [SerializeField]
    float delay;
    public static SnakeGame instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        SnakeStats.score = 1;
        SnakeStats.delay = delay;
        SnakeStats.row = row;
        SnakeStats.col = col;
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
        SnakeStats.canRun = true;
    }

    public void SummonFruit()
    {
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
        Debug.Log("GameOver");
        SnakeStats.gameRunning = false;
        SnakeStats.canRun = false;
    }

    public void UpdatePlayerPosition(int row, int col)
    {
        SnakeStats.playerPos[0] = row;
        SnakeStats.playerPos[1] = col;
        SnakeStats.gameState[row, col] = 1;
        SnakeGridManager.instance.CreateTile(row, col, 1);
    }
}
