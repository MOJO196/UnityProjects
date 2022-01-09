using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnakeData : MonoBehaviour
{
    bool resetData = false; //set true to reset all data
    public object[,] score; //level, totalscore, avg. Score, times played, last time played

    public SnakeData()
    {
        if (SaveSystem.LoadSnake() != null || !resetData)
        {
            SnakeData oldData = SaveSystem.LoadSnake();
            score = oldData.score;
        }
        else
        {
            score = new object[6, 5]
            {
                {0, 0, 0, 0, null},
                {1, 0, 0, 0, null},
                {2, 0, 0, 0, null},
                {3, 0, 0, 0, null},
                {4, 0, 0, 0, null},
                {5, 0, 0, 0, null}
            };
        }

        score[SnakeStats.level, 1] = SnakeStats.score + (int)score[SnakeStats.level, 1];
        score[SnakeStats.level, 2] = (int)score[SnakeStats.level, 1] / ((int)score[SnakeStats.level, 3] + 1);
        score[SnakeStats.level, 3] = (int)score[SnakeStats.level, 3] + 1;
        score[SnakeStats.level, 4] = System.DateTime.Now.ToString("dd/MM/ HH:mm:ss");
    }
}
