using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeLevelButton : Buttons
{
    int level = -1;

    public override void OnClick()
    {
        level++;

        switch (level)
        {
            case 0:
                GameObject.Find("Level").GetComponentInChildren<Text>().text = "easy";
                SnakeStats.col = 9;
                SnakeStats.row = 11;
                SnakeStats.delay = 1f;
                SnakeStats.level = 0;
                SnakeStats.camSize = 5;
                return;
            case 1:
                GameObject.Find("Level").GetComponentInChildren<Text>().text = "medium";
                SnakeStats.col = 11;
                SnakeStats.row = 13;
                SnakeStats.delay = .5f;
                SnakeStats.level = 1;
                SnakeStats.camSize = 6;
                return;
            case 2:
                GameObject.Find("Level").GetComponentInChildren<Text>().text = "hard";
                SnakeStats.col = 13;
                SnakeStats.row = 15;
                SnakeStats.delay = .2f;
                SnakeStats.level = 2;
                SnakeStats.camSize = 7;
                return;
            default:
                level = -1;
                OnClick();
                return;
        }
    }
}
