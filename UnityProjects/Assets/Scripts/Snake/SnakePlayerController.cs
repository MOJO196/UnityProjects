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

            if (SnakeStats.gameState[SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]] == -1) SnakeStats.score++;

            //if (SnakeStats.playerPos[0]++ < 0 || (SnakeStats.gameState[SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]] != 0 &&
            //!(SnakeStats.gameState[SnakeStats.playerPos[0]++, SnakeStats.playerPos[1]] == SnakeStats.score))) SnakeGame.instance.GameOver();
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
                SnakeStats.score++;
                MakeMove(2, true);
                return;
            }

            //if (SnakeStats.playerPos[0]-- < SnakeStats.row || (SnakeStats.gameState[SnakeStats.playerPos[0]--, SnakeStats.playerPos[1]] != 0 &&
            //!(SnakeStats.gameState[SnakeStats.playerPos[0]--, SnakeStats.playerPos[1]] == SnakeStats.score))) SnakeGame.instance.GameOver();
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
                SnakeStats.score++;
                MakeMove(3, true);
                return;
            }

            //if (SnakeStats.playerPos[1]-- < SnakeStats.col || (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]--] != 0 &&
            //!(SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]--] == SnakeStats.score))) SnakeGame.instance.GameOver();
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
                SnakeStats.score++;
                MakeMove(4, true);
                return;
            }

            //if (SnakeStats.playerPos[1]++ < 0 || (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]++] != 0 &&
            //!(SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1]]++ == SnakeStats.score))) SnakeGame.instance.GameOver();
            else MakeMove(4, false);
        }
    }

    void MakeMove(int direction, bool fruit)
    {
        SnakeStats.score++;
        for (int i = 0; i < SnakeStats.row; i++)
        {
            for (int j = 0; j < SnakeStats.col; j++)
            {
                if (SnakeStats.gameState[i, j] != -1 && SnakeStats.gameState[i, j] != 0)
                {
                    SnakeStats.gameState[i, j]++;

                    if (SnakeStats.gameState[i, j] > SnakeStats.score) SnakeStats.gameState[i, j] = 0;
                    else SnakeGridManager.instance.EditTileColor(i, j);
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
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        duringMove = false;
    }
}
