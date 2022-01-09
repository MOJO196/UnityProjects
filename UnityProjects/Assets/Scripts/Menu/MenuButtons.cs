using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    int ticTacToeAIlevel, snakeLevel;
    [SerializeField]
    int gameLocation, backLocation, gameID, maxPoints;
    [SerializeField]
    bool showScore, resetGameStats;

    void Start() //Default Settings
    {
        switch (gameID)
        {
            case 0: //No Game Selected
                return;
            case 1: //TicTacToe
                if (resetGameStats) //Default settings
                {
                    ticTacToeAIlevel = TicTacToeStats.AILevel - 1;
                    TicTacToeAILevel();
                    switch (TicTacToeStats.pointsNeedToWin)
                    {
                        case 5:
                            maxPoints = 0;
                            break;
                        case 256:
                            maxPoints = 1;
                            break;
                        default:
                            maxPoints = -1;
                            break;
                    }
                    TicTacToeMaxPoints();
                    TicTacToeStats.duringRestart = false;
                    TicTacToeStats.duringMove = false;
                    TicTacToeStats.matchpoint = false;
                    TicTacToeStats.player1Score = 0;
                    TicTacToeStats.player2Score = 0;
                    TicTacToeStats.moves = 0;

                    for (int i = 0; i < 9; i++) TicTacToeStats.buttonUsed[i] = 0;
                }

                if (showScore)
                {
                    GameObject.Find("Score").GetComponentInChildren<Text>().text = "Score : " + TicTacToeStats.player1Score.ToString() + " - " + TicTacToeStats.player2Score.ToString();
                    OverallScore();
                    //Animation which player won
                }
                return;
            case 2: //Pong
                return;
            case 3: //Snake
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
        ticTacToeAIlevel++;

        switch (ticTacToeAIlevel)
        {
            case 0:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "No AI";
                TicTacToeStats.AILevel = ticTacToeAIlevel;
                return;
            case 1:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - easy";
                TicTacToeStats.AILevel = ticTacToeAIlevel;
                return;
            case 2:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - medium";
                TicTacToeStats.AILevel = ticTacToeAIlevel;
                return;
            case 3:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - hard";
                TicTacToeStats.AILevel = ticTacToeAIlevel;
                return;
            case 4:
                GameObject.Find("AILevel").GetComponentInChildren<Text>().text = "AI Level - very hard";
                TicTacToeStats.AILevel = ticTacToeAIlevel;
                return;
            default:
                ticTacToeAIlevel = -1;
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
                TicTacToeStats.pointsNeedToWin = 256; //Nobody will reach this amount of rounds
                return;
            default:
                maxPoints = -1;
                TicTacToeMaxPoints();
                return;
        }
    }

    void OverallScore()
    {
        TicTacToeData data = SaveSystem.LoadTicTacToe();
        Debug.Log("-------------------");
        for (int i = 0; i < 6; i++) Debug.Log(data.score[i, 1] + " - " + data.score[i, 2] + " last time played : " + data.score[i, 3]);
        Debug.Log("-------------------");
    }

    //Snake
    public void SnakeLevel()
    {
        snakeLevel++;

        switch (maxPoints)
        {
            case 0:
                GameObject.Find("level").GetComponentInChildren<Text>().text = "easy";
                SnakeStats.col = 9;
                SnakeStats.row = 9;
                SnakeStats.delay = 1f;
                return;
            case 1:
                GameObject.Find("level").GetComponentInChildren<Text>().text = "medium";
                SnakeStats.col = 11;
                SnakeStats.row = 11;
                SnakeStats.delay = .5f;
                return;
            case 2:
                GameObject.Find("level").GetComponentInChildren<Text>().text = "hard";
                SnakeStats.col = 15;
                SnakeStats.row = 19;
                SnakeStats.delay = .2f;
                return;
            default:
                maxPoints = -1;
                SnakeLevel();
                return;
        }
    }

    //Error
    void Error(int code)
    {
        switch (code)
        {
            case 0:
                Debug.Log("No game selected");
                return;
            case 1:
                Debug.Log("You dont want to go to this scene");
                return;
            default:
                Debug.Log("Wrong ERROR code!");
                return;
        }
    }
}
