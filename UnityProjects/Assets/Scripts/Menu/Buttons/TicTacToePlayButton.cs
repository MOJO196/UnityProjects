using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToePlayButton : Buttons
{
    int gameLocation;

    public override void OnClick()
    {
        if (TicTacToeStats.AILevel == 0) TicTacToeStats.AILevel = 1;
        if (TicTacToeStats.pointsNeedToWin == 0) TicTacToeStats.pointsNeedToWin = 3;

        SceneLoader.instance.SetScene(gameLocation);
    }
}
