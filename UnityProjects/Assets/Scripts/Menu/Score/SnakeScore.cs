using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeScoreButton : Score
{
    [SerializeField]
    GameObject scoreObj;
    
    void Awake()
    {
        SetScore();
    }

    protected override void SetScore()
    {
        scoreObj.GetComponentInChildren<Text>().text = "Score : " + SnakeStats.score.ToString() + "Level : " + SnakeStats.level.ToString();
    }
}
