using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayButton : Buttons
{
    [SerializeField]
    int gameLocation;

    public override void OnClick()
    {
        if (SnakeStats.row == 0)
        {
            SnakeStats.row = 10;
            SnakeStats.col = 16;
            SnakeStats.delay = .5f;
            SnakeStats.level = 1;
            SnakeStats.camSize = 5;
        }

        SceneLoader.instance.SetScene(gameLocation);
    }
}
