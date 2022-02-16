using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongScore : Score
{
    [SerializeField]
    GameObject scoreObj;
    
    void Awake()
    {
        SetScore();
    }

    protected override void SetScore()
    {
        scoreObj.GetComponentInChildren<Text>().text = "Result\n" + PongStats.scorePlayer1.ToString() + " : " + PongStats.scorePlayer2.ToString();
    }
}
