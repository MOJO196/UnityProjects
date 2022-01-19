using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessOnClick : MonoBehaviour
{

    public int row, col;
    
    void OnMouseDown()
    {
        //Debug.Log(row + ", " + col);
        ChessMoveManager.instance.NewMove(row, col);
    }
}
