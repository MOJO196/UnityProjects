using System.Drawing;
using UnityEngine.UI;
public static class TicTacToeStats
{
    //Ingame
    public static bool player1ToMove;
    public static bool gameRunning;
    public static int AILevel;
    public static int moves;
    public static int[] buttonUsed = new int[9];

    //Score
    public static int player1Score;
    public static int player2Score;
    public static bool matchpoint;
    public static int pointsNeedToWin;

    //Game
    public static bool player1BeganToStart;
    public static bool duringRestart;
    public static bool duringMove = false;
}