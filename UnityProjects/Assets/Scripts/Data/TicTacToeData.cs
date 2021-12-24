using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeData
{
    private int numberOfEnemies = 5;
    public int score; //-3 => Enemy won by 3 points difference
    public int[][][]data;

    public void UpdateData()
    {
        data = new int[numberOfEnemies][][];
    }
}
