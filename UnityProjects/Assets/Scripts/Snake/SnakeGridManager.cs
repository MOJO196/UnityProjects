using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeGridManager : MonoBehaviour
{
    public static SnakeGridManager instance;
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    public void CreateGrid()
    {
        GameObject referenzTile = (GameObject)Instantiate(Resources.Load("Snake0"));

        for (int i = 0; i < SnakeStats.row; i++)
        {
            for (int j = 0; j < SnakeStats.col; j++)
            {
                GameObject tile = (GameObject)Instantiate(referenzTile, transform);

                float posX = j * SnakeStats.tileSize;
                float posY = i * -SnakeStats.tileSize;

                tile.transform.position = new Vector2(posX, posY);
                tile.name = (string)(i + ", " + j);
            }
        }

        Destroy(referenzTile);

        float gridW = SnakeStats.col * SnakeStats.tileSize;
        float gridH = SnakeStats.row * SnakeStats.tileSize;

        transform.position = new Vector2(-gridW / 2 + SnakeStats.tileSize / 2, gridH / 2 - SnakeStats.tileSize / 2);
    }

    public void CreateTile(int r, int c, int id)
    {
        Destroy(GameObject.Find((string)(r + ", " + c)));

        string spriteName;
        switch (id)
        {
            case -1:
                spriteName = "Snake-1";
                break;
            case 0:
                spriteName = "Snake0";
                break;
            case 1:
                spriteName = "Snake1";
                break;
            default:
                spriteName = "Snake2";
                break;
        }

        GameObject referenzTile = (GameObject)Instantiate(Resources.Load(spriteName));
        GameObject tile = (GameObject)Instantiate(referenzTile, transform);

        float posX = c * SnakeStats.tileSize;
        float posY = r * -SnakeStats.tileSize;

        tile.transform.position = new Vector2(posX + transform.position[0], posY + transform.position[1]);
        tile.name = (string)(r + ", " + c);

        Destroy(referenzTile);
    }
}
