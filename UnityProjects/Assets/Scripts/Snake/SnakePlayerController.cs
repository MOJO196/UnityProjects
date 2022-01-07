using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayerController : MonoBehaviour
{
    public static SnakePlayerController instance;
    bool duringMove = false;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    public void UP()
    {
        if (!duringMove)
        {
            duringMove = true;

            if (SnakeStats.gameState[SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]] == -1)
            {
                MakeMove(1, true);
                return;
            }

            if (SnakeStats.playerPos[0]++ < 0 || (SnakeStats.gameState[SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]] != 0 &&
            !(SnakeStats.gameState[SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]] == SnakeStats.score))) SnakeGame.instance.GameOver();
            else MakeMove(1, false);
        }
    }

    public void DOWN()
    {
        if (!duringMove)
        {
            duringMove = true;

            if (SnakeStats.gameState[SnakeStats.playerPos[0]--, SnakeStats.playerPos[1]] == -1)
            {
                MakeMove(2, true);
                return;
            }

            if (SnakeStats.playerPos[0]-- < SnakeStats.row || (SnakeStats.gameState[SnakeStats.playerPos[0]--, SnakeStats.playerPos[1]] != 0 &&
            !(SnakeStats.gameState[SnakeStats.playerPos[0]--, SnakeStats.playerPos[1]] == SnakeStats.score))) SnakeGame.instance.GameOver();
            else MakeMove(2, false);
        }
    }

    public void LEFT()
    {
        if (!duringMove)
        {
            duringMove = true;

            if (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]--] == -1)
            {
                MakeMove(3, true);
                return;
            }

            if (SnakeStats.playerPos[1]-- < SnakeStats.col || (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]--] != 0 &&
            !(SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]--] == SnakeStats.score))) SnakeGame.instance.GameOver();
            else MakeMove(3, false);
        }
    }

    public void RIGHT()
    {
        if (!duringMove)
        {
            duringMove = true;

            if (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]++] == -1)
            {
                MakeMove(4, true);
                return;
            }

            if (SnakeStats.playerPos[1]++ < 0 || (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]++] != 0 &&
            !(SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]]++ == SnakeStats.score))) SnakeGame.instance.GameOver();
            else MakeMove(4, false);
        }
    }

    void MakeMove(int direction, bool fruit)
    {
        for (int j = 0; j < SnakeStats.row; j++)
        {
            for (int k = 0; k < SnakeStats.col; k++)
            {
                if (SnakeStats.gameState[j, k] != -1 || SnakeStats.gameState[j, k] != 0)
                {
                    SnakeStats.gameState[j, k]++;

                    if (SnakeStats.gameState[j, k] > SnakeStats.score) SnakeStats.gameState[j, k] = 0;
                }
            }
        }

        switch (direction)
        {
            case 1: //UP
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]);
                break;
            case 2: //DOWN
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0]--, SnakeStats.playerPos[1]);
                break;
            case 3: //LEFT
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0], SnakeStats.playerPos[1]--);
                break;
            case 4: //RIGHT
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0], SnakeStats.playerPos[1]++);
                break;
        }

        duringMove = false;
    }
}
