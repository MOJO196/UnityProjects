using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public int backLocation;
    public int gameLocation;
    private int playerToBegin;
    private int AILevel;
    private int maxPoints;
    void Start() 
    {
        TicTacToeStats.pointsNeedToWin = 3;    
    }

    //General
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

    //TicTacToe
    public void TicTacToeAILevel()
    {
        AILevel++;

        switch (AILevel)
        {
            case 0:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "No AI";
                TicTacToeStats.AILevel = AILevel;
                break;
            case 1:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - easy";
                TicTacToeStats.AILevel = AILevel;
                break;
            case 2:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - medium";
                TicTacToeStats.AILevel = AILevel;
                break;
            case 3:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - hard";
                break;
            default:
                AILevel = -1;
                TicTacToeAILevel();
                break;
        }
    }

    public void TicTacToeMaxPoints()
    {
        maxPoints++;

        switch (maxPoints)
        {
            case 0:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "3 times";
                TicTacToeStats.pointsNeedToWin = 3;
                break;
            case 1:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "5 times";
                TicTacToeStats.pointsNeedToWin = 5;
                break;
            case 2:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "no limit";
                TicTacToeStats.pointsNeedToWin = 999; //Nobody will reach this amount of rounds
                break;
            case 3:
                maxPoints = -1;
                TicTacToeMaxPoints();
                break;
        }
    }

    //Error
    private void Error()
    {
        Debug.Log("You dont want to go to this scene, Error in MenuButtons");
    }
}
