using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeMaxPointsButton : Buttons
{
    int maxPoints;

    public override void OnClick()
    {
        maxPoints++;

        switch (maxPoints)
        {
            case 0:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "3 times";
                TicTacToeStats.pointsNeedToWin = 3;
                return;
            case 1:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "5 times";
                TicTacToeStats.pointsNeedToWin = 5;
                return;
            case 2:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "no limit";
                TicTacToeStats.pointsNeedToWin = 256; //Nobody will reach this amount of rounds
                return;
            default:
                maxPoints = -1;
                OnClick();
                return;
        }
    }
}
