using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakePlayerController : MonoBehaviour
{
    bool duringMove;
    int nextMoveDirection, lastMoveDirection;
    public void InputUP()
    {
        nextMoveDirection = 1;

        if (!SnakeStats.gameRunning && SnakeStats.canRun)
        {
            SnakeStats.gameRunning = true;
            DoNextMove();
        }
    }

    public void InputDOWN()
    {
        nextMoveDirection = 2;

        if (!SnakeStats.gameRunning && SnakeStats.canRun)
        {
            SnakeStats.gameRunning = true;
            DoNextMove();
        }
    }

    public void InputLEFT()
    {
        nextMoveDirection = 3;

        if (!SnakeStats.gameRunning && SnakeStats.canRun)
        {
            SnakeStats.gameRunning = true;
            DoNextMove();
        }
    }

    public void InputRIGHT()
    {
        nextMoveDirection = 4;

        if (!SnakeStats.gameRunning && SnakeStats.canRun)
        {
            SnakeStats.gameRunning = true;
            DoNextMove();
        }
    }

    void DoNextMove()
    {
        switch (nextMoveDirection)
        {
            case 1:
                if (lastMoveDirection == 2 && SnakeStats.score != 1) DOWN();
                else UP();
                break;
            case 2:
                if (lastMoveDirection == 1 && SnakeStats.score != 1) UP();
                else DOWN();
                break;
            case 3:
                if (lastMoveDirection == 4 && SnakeStats.score != 1) RIGHT();
                else LEFT();
                break;
            case 4:
                if (lastMoveDirection == 3 && SnakeStats.score != 1) LEFT();
                else RIGHT();
                break;
        }
    }

    void UP()
    {
        if (!duringMove && SnakeStats.gameRunning)
        {
            duringMove = true;

            if (SnakeStats.playerPos[0] - 1 < 0)
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0] - 1, SnakeStats.playerPos[1]] == -1)
            {
                SnakeStats.score++;
                MakeMove(1, true);
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0] - 1, SnakeStats.playerPos[1]] != 0 && !(SnakeStats.gameState[SnakeStats.playerPos[0] - 1, SnakeStats.playerPos[1]] == SnakeStats.score))
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else MakeMove(1, false);
        }
    }

    void DOWN()
    {
        if (!duringMove && SnakeStats.gameRunning)
        {
            duringMove = true;

            if (SnakeStats.playerPos[0] + 1 > SnakeStats.row - 1)
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0] + 1, SnakeStats.playerPos[1]] == -1)
            {
                SnakeStats.score++;
                MakeMove(2, true);
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0] + 1, SnakeStats.playerPos[1]] != 0 && !(SnakeStats.gameState[SnakeStats.playerPos[0] + 1, SnakeStats.playerPos[1]] == SnakeStats.score))
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else MakeMove(2, false);
        }
    }

    void LEFT()
    {
        if (!duringMove && SnakeStats.gameRunning)
        {
            duringMove = true;

            if (SnakeStats.playerPos[1] - 1 < 0)
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1] - 1] == -1)
            {
                SnakeStats.score++;
                MakeMove(3, true);
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1] - 1] != 0 && !(SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1] - 1] == SnakeStats.score))
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else MakeMove(3, false);
        }
    }

    void RIGHT()
    {
        if (!duringMove && SnakeStats.gameRunning)
        {
            duringMove = true;

            if (SnakeStats.playerPos[1] + 1 > SnakeStats.col - 1)
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1] + 1] == -1)
            {
                SnakeStats.score++;
                MakeMove(4, true);
                return;
            }
            else if (SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1] + 1] != 0 && !(SnakeStats.gameState[SnakeStats.playerPos[0], SnakeStats.playerPos[1] + 1] == SnakeStats.score))
            {
                SnakeGame.instance.GameOver();
                return;
            }
            else MakeMove(4, false);
        }
    }

    void MakeMove(int direction, bool fruit)
    {
        nextMoveDirection = direction;  //if nothing happens this will be our next move
        lastMoveDirection = direction;  //save last move to avoid stupid mistakes

        for (int i = 0; i < SnakeStats.row; i++)
        {
            for (int j = 0; j < SnakeStats.col; j++)
            {
                if (SnakeStats.gameState[i, j] != -1 && SnakeStats.gameState[i, j] != 0)
                {
                    SnakeStats.gameState[i, j]++;

                    if (SnakeStats.gameState[i, j] > SnakeStats.score)
                    {
                        SnakeStats.gameState[i, j] = 0;
                        SnakeGridManager.instance.CreateTile(i, j, 0);
                    }
                    else SnakeGridManager.instance.CreateTile(i, j, 2);
                }
            }
        }

        switch (direction)
        {
            case 1: //UP
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0] - 1, SnakeStats.playerPos[1]);
                break;
            case 2: //DOWN
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0] + 1, SnakeStats.playerPos[1]);
                break;
            case 3: //LEFT
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0], SnakeStats.playerPos[1] - 1);
                break;
            case 4: //RIGHT
                SnakeGame.instance.UpdatePlayerPosition(SnakeStats.playerPos[0], SnakeStats.playerPos[1] + 1);
                break;
        }

        if (fruit) SnakeGame.instance.SummonFruit();

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(SnakeStats.delay);
        duringMove = false;
        DoNextMove();
    }
}
