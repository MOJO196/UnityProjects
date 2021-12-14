using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeDrawLine : MonoBehaviour
{
    private LineRenderer line;
    public static TicTacToeDrawLine instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        line = this.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;
        line.positionCount = 2;
    }

    public void DrawLine(Button obj1, Button obj2)
    {
        if (obj1 != null && obj2 != null)
        {
            line.SetPosition(0, obj1.transform.position);
            line.SetPosition(1, obj2.transform.position);
        }
    }
}
