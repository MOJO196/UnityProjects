using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongScoreManager : MonoBehaviour
{
    public static PongScoreManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private int scorePlayer1;
    private int scorePlayer2;

    public bool Score(int player)
    {
        if (player == 1)
            scorePlayer1 += 1;
        else if (player == 2)
            scorePlayer2 += 1;

        return CheckIfPlayerWon();
    }

    private bool CheckIfPlayerWon()
    {
        if (scorePlayer1 >= 5)
        {
            //Player 1 won
            Debug.Log("Player 1 won");
            return true;
        }
        else if (scorePlayer2 == 5)
        {
            //Player 2 won
            Debug.Log("Player 2 won");
            return true;
        }
        else if (scorePlayer1 == 4 || scorePlayer2 == 4)
        {
            //Matchpoint
        }

        return false;
    }
}
