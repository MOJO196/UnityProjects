using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    private int AILevel;
    private int maxPoints;
    [SerializeField]
    private int gameID = -1;
    [SerializeField]
    public int gameLocation;
    [SerializeField]
    public int backLocation;

    void Start() //Default Settings
    {
        switch (gameID)
        {
            case 0: //No Game Selected
                return;
            case 1: //TicTacToe
                TicTacToeStats.pointsNeedToWin = 3;
                TicTacToeStats.AILevel = 0;                
                TicTacToeStats.duringRestart = false;
                TicTacToeStats.duringMove = false;
                TicTacToeStats.matchpoint = false;
                TicTacToeStats.player1Score = 0;
                TicTacToeStats.player2Score = 0;
                TicTacToeStats.moves = 0;

                for (int i = 0; i < 9; i++) TicTacToeStats.buttonUsed[i] = 0;
                return;
            case 2:
                return;
            case 3:
                return;
            case 4:
                return;
            case 5:
                return;
            case 6:
                return;
            default:
                Error(0);
                return;
        }
    }

    //General
    public void BackButton()
    {
        if (backLocation < SceneLoader.instance.GetTotalNumberOfScenes()) SceneLoader.instance.SetScene(backLocation);  //wrong scenes could go here
        else Error(2);
    }

    public void StartButton()
    {
        if (gameLocation < SceneLoader.instance.GetTotalNumberOfScenes()) SceneLoader.instance.SetScene(gameLocation);  //wrong scenes could go here
        else Error(2);
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
                return;
            case 1:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - easy";
                TicTacToeStats.AILevel = AILevel;
                return;
            case 2:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - medium";
                TicTacToeStats.AILevel = AILevel;
                return;
            case 3:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - hard";
                return;
            default:
                AILevel = -1;
                TicTacToeAILevel();
                return;
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
                return;
            case 1:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "5 times";
                TicTacToeStats.pointsNeedToWin = 5;
                return;
            case 2:
                GameObject.Find("PointsToWin").GetComponentInChildren<Text>().text = "no limit";
                TicTacToeStats.pointsNeedToWin = 999; //Nobody will reach this amount of rounds
                return;
            case 3:
                maxPoints = -1;
                TicTacToeMaxPoints();
                return;
        }
    }

    //Error
    private void Error(int code)
    {
        switch (code)
        {
            case 0:
                Debug.Log("No game selected");
                return;
            case 1:
                Debug.Log("You dont want to go to this scene");
                return;
            case 2:
                return;
            case 3:
                return;
            default:
                Debug.Log("Worng code");
                return;
        }
    }
}
