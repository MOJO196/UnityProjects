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

        SnakeStats.row = horizontal * 2;
        SnakeStats.col = vertical * 2;

        SnakeStats.gameState = new int[SnakeStats.row, SnakeStats.col];
    }

    public void UpdateGrid()
    {
        for (int i = 0; i < SnakeStats.row; i++)
        {
            for (int j = 0; j < SnakeStats.col; j++)
            {
                switch (SnakeStats.gameState[i, j])
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
                    default:
                        SpawnTile(i, j, new Color(.5f, .2f, .4f));
                        break;
                }
            }
        }
    }

    void SpawnTile(int x, int y, Color color)
    {
        GameObject g = new GameObject("X: " + x + "Y: " + y);
        g.transform.position = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = color;
    }
}
