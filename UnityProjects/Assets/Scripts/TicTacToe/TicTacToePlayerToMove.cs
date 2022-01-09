using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToePlayerToMove : MonoBehaviour
{
    [SerializeField]
    Image image;
    public static TicTacToePlayerToMove instance;
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        if (!(TicTacToeStats.AILevel == 0)) this.gameObject.SetActive(false);
    }

    public void PlayerToMove()
    {
        if (TicTacToeStats.player1ToMove) image.color = Color.blue;
        else image.color = Color.red;
    }
}
