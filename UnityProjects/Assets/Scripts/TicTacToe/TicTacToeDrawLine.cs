using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeDrawLine : MonoBehaviour
{
    private LineRenderer line;
    private float alpha = 1f;
    public Color color = Color.black;
    public static TicTacToeDrawLine instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        line = this.gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));

        line.startWidth = .25f;
        line.endWidth = .25f;
        line.positionCount = 2;
    }

    public void DrawLine(Button obj1, Button obj2)
    {
        if (obj1 != null && obj2 != null)
        {
            line.SetPosition(0, obj1.transform.position + new Vector3(0f, 0f, -1f));
            line.SetPosition(1, obj2.transform.position + new Vector3(0f, 0f, -1f));

            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0f), new GradientAlphaKey(alpha, 1f) }
            );
            line.colorGradient = gradient;
        }
    }

    public void ResetLine()
    {
        line.positionCount = 0;
        line.positionCount = 2;
    }
}
