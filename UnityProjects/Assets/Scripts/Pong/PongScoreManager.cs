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
    }

    public bool Score(int player)
    {
        if (player == 1) PongStats.scorePlayer1 += 1;
        else if (player == 2) PongStats.scorePlayer2 += 1;

        return CheckIfPlayerWon();
    }

    
    bool CheckIfPlayerWon()
    {
        if (PongStats.scorePlayer1 >= 5)
        {
            //Player 1 won
            Debug.Log("Player 1 won");
            return true;
        }
        else if (PongStats.scorePlayer2 == 5)
        {
            //Player 2 won
            Debug.Log("Player 2 won");
            return true;
        }
        else if (PongStats.scorePlayer1 == 4 || PongStats.scorePlayer2 == 4)
        {
            //Matchpoint
        }

        return false;
    }
}
