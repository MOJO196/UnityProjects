using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    public static SnakeGame instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
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
        SnakeGridManager.instance.CreateNewGrid();
        SatrtingPosition();
        SummonFruit();
        SnakeGridManager.instance.UpdateGrid();
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
        SnakeGridManager.instance.UpdateGrid();
    }
}
