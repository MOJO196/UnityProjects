using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToePlayerToMove : MonoBehaviour
{
    public static TicTacToePlayerToMove instance;
    public Image image;
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        if (TicTacToeStats.computer)
            this.gameObject.SetActive(false);
    }

    public void PlayerToMove()
    {
        if (TicTacToeStats.player1ToMove)
            image.color = Color.blue;
        else
            image.color = Color.red;
    }
}
