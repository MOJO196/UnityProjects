using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGridManager : MonoBehaviour
{
    int vertical, horizontal;
    [SerializeField]
    Sprite sprite;
    public static SnakeGridManager instance;
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    public void CreateNewGrid()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = (int)(vertical * Camera.main.aspect);

        SnakeStats.col = horizontal * 2;
        SnakeStats.row = vertical * 2;

        SnakeStats.gameState = new int[SnakeStats.row, SnakeStats.col];
    }

    public void UpdateGrid()
    {
        for (int i = 0; i < SnakeStats.col; i++)
        {
            for (int j = 0; j < SnakeStats.row; j++)
            {
                switch (SnakeStats.gameState[j, i])
                {
                    case -1:
                        SpawnTile(i, j, Color.green);
                        break;
                    case 0:
                        SpawnTile(i, j, Color.white);
                        break;
                    case 1:
                        SpawnTile(i, j, Color.red);
                        break;
                }
            }
        }
    }

    public void EditTileColor(int x, int y)
    {
        string name = (string)(x + ", " + y);
        GameObject.Find(name).GetComponent<SpriteRenderer>().color = Color.black;
    }

    void SpawnTile(int x, int y, Color color)
    {
        GameObject g = new GameObject(x + ", " + y);
        g.transform.position = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = color;
    }
}
