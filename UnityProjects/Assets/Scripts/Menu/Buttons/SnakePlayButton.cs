using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlayButton : Buttons
{
    [SerializeField]
    int gameLocation;

    public override void OnClick()
    {
        if (SnakeStats.col == 0)
        {
            SnakeStats.col = 9;
            SnakeStats.row = 9;
            SnakeStats.delay = 1f;
            SnakeStats.level = 0;
            SnakeStats.camSize = 5;
        }

        SceneLoader.instance.SetScene(gameLocation);
    }
}
