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
    public void TicTacToePlayerToBegin()
    {
        playerToBegin++;

        switch (playerToBegin)
        {
            case 0:
                GameObject.Find("PlayerToBeginn").GetComponentInChildren<Text>().text = "A random player will beginn";
                if (Random.value >= 0.5)
                    TicTacToeStats.player1ToMove = true;
                else
                    TicTacToeStats.player1ToMove = false;
                break;
            case 1:
                GameObject.Find("PlayerToBeginn").GetComponentInChildren<Text>().text = "Player 1 will beginn";
                TicTacToeStats.player1ToMove = true;
                break;
            case 2:
                GameObject.Find("PlayerToBeginn").GetComponentInChildren<Text>().text = "Player 2 will beginn";
                TicTacToeStats.player1ToMove = false;
                break;
            case 3:
                playerToBegin = -1;
                TicTacToePlayerToBegin();
                break;
        }
    }

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
                AILevel = -1;
                TicTacToeAILevel();
                break;
        }
    }

    public void TicTacToeMaxPoints()
    {
        maxPoints++;

        switch (AILevel)
        {
            case 0:
                GameObject.Find("MaxPoints").GetComponentInChildren<Text>().text = "You will need to win 5 times";
                TicTacToeStats.pointsNeedToWin = 5;
                break;
            case 1:
                GameObject.Find("MaxPoints").GetComponentInChildren<Text>().text = "You will need to win 3 times";
                TicTacToeStats.pointsNeedToWin = 3;
                break;
            case 2:
                GameObject.Find("MaxPoints").GetComponentInChildren<Text>().text = "You dont have a win limit";
                TicTacToeStats.pointsNeedToWin = 999; //Nobody will reach this number of rounds
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
