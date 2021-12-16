﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeDrawLine2 : TicTacToeLineManager
{
    public static TicTacToeDrawLine2 instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public override void DrawLine(Button obj1, Button obj2)
    {
        base.DrawLine(obj1, obj2);
    }

    public override void ResetLine()
    {
        base.ResetLine();
    }
}