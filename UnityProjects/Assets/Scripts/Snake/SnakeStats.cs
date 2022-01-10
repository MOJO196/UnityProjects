public static class SnakeStats
{
    public static int[,] gameState; //fruit = -1, empty = 0, player = 1..n
    public static int[] playerPos = new int[2];
    public static bool gameRunning, canRun;
    public static int row, col, score, level;
    public static float delay, camSize;
}
