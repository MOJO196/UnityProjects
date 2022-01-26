using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeAIButton : Buttons
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
                levelButton.GetComponentInChildren<Text>().text = "No AI";
                TicTacToeStats.AILevel = level;
                return;
            case 1:
                levelButton.GetComponentInChildren<Text>().text = "AI Level - easy";
                TicTacToeStats.AILevel = level;
                return;
            case 2:
                levelButton.GetComponentInChildren<Text>().text = "AI Level - medium";
                TicTacToeStats.AILevel = level;
                return;
            case 3:
                levelButton.GetComponentInChildren<Text>().text = "AI Level - hard";
                TicTacToeStats.AILevel = level;
                return;
            case 4:
                levelButton.GetComponentInChildren<Text>().text = "AI Level - very hard";
                TicTacToeStats.AILevel = level;
                return;
            //case 5:
                //levelButton.GetComponentInChildren<Text>().text = "AI Level - impossible";
                //TicTacToeStats.AILevel = level - 1;
                //return;
            default:
                level = -1;
                OnClick();
                return;
        }
    }
}
