using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessages : MonoBehaviour
{
    public void TicTacToeError(int message)
    {
        switch (message)
        {
            case 0:
                return;
            default:
                Debug.Log("Unknown error message!");
                return;
        }
    }

    public void SnakeError(int message)
    {
        switch (message)
        {
            case 0:
                return;
            default:
                Debug.Log("Unknown error message!");
                return;
        }
    }

    public void PongError(int message)
    {
        switch (message)
        {
            case 0:
                return;
            default:
                Debug.Log("Unknown error message!");
                return;
        }
    }
}
