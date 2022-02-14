using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeLevelButton : Buttons
{
    [SerializeField]
    GameObject levelButton;
    int level;

    public override void OnClick()
    {
        level++;

        switch (level)
        {
            case 0:
                levelButton.GetComponentInChildren<Text>().text = "easy";
                SnakeStats.row = 10;
                SnakeStats.col = 16;
                SnakeStats.delay = .5f;
                SnakeStats.level = 1;
                SnakeStats.camSize = 5;
                return;
            case 1:
                levelButton.GetComponentInChildren<Text>().text = "medium";
                SnakeStats.row = 10;
                SnakeStats.col = 16;
                SnakeStats.delay = .35f;
                SnakeStats.level = 1;
                SnakeStats.camSize = 5;
                return;
            case 2:
                levelButton.GetComponentInChildren<Text>().text = "hard";
                SnakeStats.row = 14;
                SnakeStats.col = 24;
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
