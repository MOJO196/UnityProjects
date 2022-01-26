using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToePlayButton : Buttons
{
    public int gameLocation;

    public override void OnClick()
    {
        if (TicTacToeStats.pointsNeedToWin == 0) TicTacToeStats.pointsNeedToWin = 3;

        SceneLoader.instance.SetScene(gameLocation);
    }
}
