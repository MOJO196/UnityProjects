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

                tile.transform.position = new Vector2(j, -i);
                tile.name = (string)(i + ", " + j);
            }
        }

        Destroy(referenzTile);
        transform.position = new Vector2(-SnakeStats.col / 2 + .5f, SnakeStats.row / 2 - .5f);
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

        tile.transform.position = new Vector2(c + transform.position[0], -r + transform.position[1]);
        tile.name = (string)(r + ", " + c);

        Destroy(referenzTile);
    }
}
