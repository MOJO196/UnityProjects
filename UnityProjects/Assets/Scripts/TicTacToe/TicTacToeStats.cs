using System.Drawing;
using UnityEngine.UI;
public static class TicTacToeStats
{
    public static int[] buttonUsed = new int[9];
    public static int player1Score, player2Score, pointsNeedToWin, moves, AILevel;
    public static bool gameRunning, player1ToMove, player1BeganToStart, duringRestart, duringMove, matchpoint;
}