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

        SnakeStats.row = rowSize;
        SnakeStats.col = colSize;
    }

    void Start() 
    {
        CreateNewGame();
    }

    public void CreateNewGame()
    {
        SnakeGridManager.instance.CreateNewGrid();

        UpdatePlayerPosition(SnakeStats.row / 2, SnakeStats.col / 2);
        SummonFruit();
        SnakeGridManager.instance.UpdateGrid();
        SnakeStats.gameRunning = true;
    }

    public void SummonFruit()
    {
        SnakeStats.score++;

        for (; ; )
        {
            int fruitRow = Random.Range(0, SnakeStats.row + 1);
            int fruitCol = Random.Range(0, SnakeStats.col + 1);

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
