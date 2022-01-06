using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGame : MonoBehaviour
{
    [SerializeField]
    private int rowSize;    //should not be even
    [SerializeField]
    private int colSize;    //should not be even
    public static SnakeGame instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        SnakeStats.rowSize = rowSize;
        SnakeStats.colSize = colSize;
    }

    public void CreateNewGame()
    {
        SnakeStats.gameRunning = true;
        SnakeStats.gameState = new int[SnakeStats.rowSize, SnakeStats.colSize];

        //starting position
        UpdatePlayerPosition(SnakeStats.rowSize / 2 + 1, SnakeStats.colSize / 2 + 1);
        SummonFruit();
    }

    public void SummonFruit()
    {
        SnakeStats.score++;

        for (; ; )
        {
            int fruitRow = Random.Range(0, SnakeStats.rowSize);
            int fruitCol = Random.Range(0, SnakeStats.colSize);

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
    }
}
