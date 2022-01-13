using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMoveManager : MonoBehaviour
{
    public static ChessMoveManager instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    public void MakeMove(ChessMove move)
    {
        if ((string)move.move[4] == "--")
        {
            return;
        }
        else if (ChessStats.whiteToMove)
        {
            if ((string)move.move[4] == "WP")
            {

            }
            else if ((string)move.move[4] == "WR")
            {

            }
            else if ((string)move.move[4] == "WN")
            {

            }
            else if ((string)move.move[4] == "WB")
            {

            }
            else if ((string)move.move[4] == "WQ")
            {

            }
            else if ((string)move.move[4] == "WK")
            {

            }
        }
        else
        {
            if ((string)move.move[4] == "BP")
            {

            }
            else if ((string)move.move[4] == "BR")
            {

            }
            else if ((string)move.move[4] == "BN")
            {

            }
            else if ((string)move.move[4] == "BB")
            {

            }
            else if ((string)move.move[4] == "BQ")
            {

            }
            else if ((string)move.move[4] == "BK")
            {

            }
        }
    }
}
