﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeScoreButton : Score
{
    void Awake()
    {
        SetScore();
    }

    protected override void SetScore()
    {
        base.SetScore();
    }
}