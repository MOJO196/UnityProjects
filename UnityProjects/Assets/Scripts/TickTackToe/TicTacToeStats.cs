using System.Drawing;
using UnityEngine.UI;
public static class TicTacToeStats
{
    //Ingame
    public static bool player1ToMove;
    public static bool gameRunning = true;
    public static int moves;
    public static int[] buttonUsed = new int[9];
    //Result
    public static bool draw;
    public static bool player1Won;
    public static bool player2Won;
    //Score
    public static float player1Score;
    public static float player2Score;
    //GameModes
    public static bool computer;
    public static int AILevel;
}