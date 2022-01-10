using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeAIButton : Buttons
{
    int level;
    public override void OnClick()
    {
        level++;

        switch (level)
        {
            case 0:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "No AI";
                TicTacToeStats.AILevel = level;
                return;
            case 1:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - easy";
                TicTacToeStats.AILevel = level;
                return;
            case 2:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - medium";
                TicTacToeStats.AILevel = level;
                return;
            case 3:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - hard";
                TicTacToeStats.AILevel = level;
                return;
            case 4:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - very hard";
                TicTacToeStats.AILevel = level;
                return;
            case 5:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - impossible";
                TicTacToeStats.AILevel = level - 1;
                return;
            default:
                level = -1;
                OnClick();
                return;
        }
    }
}
