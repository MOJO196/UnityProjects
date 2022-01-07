using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SnakeStats
{
    public static int score; //player size
    public static int[,] gameState;    //fruit = -1, empty = 0, player = 1..n
    public static int[] playerPos = new int[2];
    public static bool gameRunning;
    public static int row;
    public static int col;
}
