﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public int backLocation;
    public int gameLocation;

    public void BackButton()
    {
        if (backLocation < SceneLoader.instance.GetTotalNumberOfScenes()) //wrong scenes could go here
            SceneLoader.instance.SetScene(backLocation);
        else
            Error();
    }

    public void StartButton()
    {
        if (gameLocation < SceneLoader.instance.GetTotalNumberOfScenes()) //wrong scenes could go here
            SceneLoader.instance.SetScene(gameLocation);
        else
            Error();
    }

    public void TicTacToePlayerSelect()
    {
        //Saves the given settings for the game in TicTacToeStats
        //First deaktivate current buttons and aktivate new ones
    }

    private void Error()
    {
        Debug.Log("You dont want to go to this scene, Error in MenuButtons");
    }
}
