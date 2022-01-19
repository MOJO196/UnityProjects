using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChessGridManager : MonoBehaviour
{
    public static ChessGridManager instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        transform.position = new Vector2(-ChessStats.col / 2 + .5f, ChessStats.row / 2 - .5f);
    }

    public void CreateGrid()
    {
        Background();

        //pawns
        DrawPawns(1, false);
        DrawPawns(6, true);
        //other tiles

        //black
        DrawTile(8, false, 0, 0);
        DrawTile(8, false, 0, 7);
        DrawTile(9, false, 0, 1);
        DrawTile(9, false, 0, 6);
        DrawTile(10, false, 0, 2);
        DrawTile(10, false, 0, 5);
        DrawTile(11, false, 0, 3);
        DrawTile(12, false, 0, 4);

        //white
        DrawTile(2, true, 7, 0);
        DrawTile(2, true, 7, 7);
        DrawTile(3, true, 7, 1);
        DrawTile(3, true, 7, 6);
        DrawTile(4, true, 7, 2);
        DrawTile(4, true, 7, 5);
        DrawTile(5, true, 7, 3);
        DrawTile(6, true, 7, 4);

    }

    void Background()
    {
        GameObject referenzTile1 = (GameObject)Instantiate(Resources.Load("Chess/ChessBackground0"));
        GameObject referenzTile2 = (GameObject)Instantiate(Resources.Load("Chess/ChessBackground1"));
        bool bool1 = true;
        bool bool2 = true;

        for (int r = 0; r < ChessStats.row; r++)
        {
            bool1 = !bool1;
            bool2 = bool1;
            for (int c = 0; c < ChessStats.col; c++)
            {
                GameObject tile;
                bool2 = !bool2;

                if (bool2) tile = (GameObject)Instantiate(referenzTile1, transform);
                else tile = (GameObject)Instantiate(referenzTile2, transform);

                tile.transform.position = new Vector3(c + transform.position[0], -r + transform.position[1], transform.position[2] + 1f);
                tile.name = (string)("Background(" + r + ", " + c + ")");

                tile.AddComponent(typeof(BoxCollider2D));
                tile.AddComponent<ChessOnClick>();
                tile.GetComponent<ChessOnClick>().row = r;
                tile.GetComponent<ChessOnClick>().col = c;
            }
        }

        Destroy(referenzTile1);
        Destroy(referenzTile2);
    }

    void DrawPawns(int r, bool white)
    {
        GameObject referenzTile;
        if (white) referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWP"));
        else referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBP"));

        for (int c = 0; c < ChessStats.col; c++)
        {
            GameObject tile = (GameObject)Instantiate(referenzTile, transform);

            tile.transform.position = new Vector2(c + transform.position[0], -r + transform.position[1]);
            tile.name = (string)(r + ", " + c);
        }

        Destroy(referenzTile);
    }

    public void DrawTile(int tileID, bool white, int r, int c)
    {
        //tileID : 0 - "--", 1 - 'R', 2 - 'N', 3 - 'B', 4 - 'K', 5 - 'Q'
        GameObject referenzTile;

        if (tileID == 0)
        {
            try
            {
                //delete tile
                Destroy(GameObject.Find((string)(r + ", " + c)));
            }
            catch { } //do nothing if tile not found
            return;
        }
        else if (white)
        {
            switch (tileID)
            {
                case 1:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWP"));
                    break;
                case 2:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWR"));
                    break;
                case 3:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWN"));
                    break;
                case 4:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWB"));
                    break;
                case 5:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWQ"));
                    break;
                case 6:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessWK"));
                    break;
                default:
                    ErrorMessages.instance.ChessError(0);
                    return;
            }
        }
        else
        {
            switch (tileID)
            {
                case 7:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBP"));
                    break;
                case 8:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBR"));
                    break;
                case 9:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBN"));
                    break;
                case 10:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBB"));
                    break;
                case 11:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBQ"));
                    break;
                case 12:
                    referenzTile = (GameObject)Instantiate(Resources.Load("Chess/ChessBK"));
                    break;
                default:
                    ErrorMessages.instance.ChessError(0);
                    return;
            }
        }

        GameObject tile = (GameObject)Instantiate(referenzTile, transform);

        tile.transform.position = new Vector2(c + transform.position[0], -r + transform.position[1]);
        tile.name = (string)(r + ", " + c);
        Destroy(referenzTile);
    }
}
