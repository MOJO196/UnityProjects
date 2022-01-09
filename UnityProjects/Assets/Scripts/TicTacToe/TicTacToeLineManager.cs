using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeLineManager : MonoBehaviour
{
    [SerializeField]
    LineRenderer line1;
    [SerializeField]
    LineRenderer line2;
    [SerializeField]
    Color color = Color.black;
    [SerializeField]
    float width = .25f;
    float alpha = 1f;
    int positionCount = 2;
    public static TicTacToeLineManager instance;

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        line1.startWidth = width;
        line1.endWidth = width;
        line1.positionCount = positionCount;

        line2.startWidth = width;
        line2.endWidth = width;
        line2.positionCount = positionCount;
    }

    public void DrawLine(int lineIndex, Button obj1, Button obj2)
    {
        if (lineIndex == 1) DrawLine1(obj1, obj2);
        else DrawLine2(obj1, obj2);
    }

    void DrawLine1(Button obj1, Button obj2)
    {
        if (obj1 != null && obj2 != null)
        {
            line1.SetPosition(0, obj1.transform.position + new Vector3(0f, 0f, -1f));
            line1.SetPosition(1, obj2.transform.position + new Vector3(0f, 0f, -1f));

            Gradient gradient1 = new Gradient();
            gradient1.SetKeys(
                new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0f), new GradientAlphaKey(alpha, 1f) }
            );
            line1.colorGradient = gradient1;
        }
    }

    void DrawLine2(Button obj1, Button obj2)
    {
        if (obj1 != null && obj2 != null)
        {
            line2.SetPosition(0, obj1.transform.position + new Vector3(0f, 0f, -1f));
            line2.SetPosition(1, obj2.transform.position + new Vector3(0f, 0f, -1f));

            Gradient gradient2 = new Gradient();
            gradient2.SetKeys(
                new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0f), new GradientAlphaKey(alpha, 1f) }
            );
            line2.colorGradient = gradient2;
        }
    }



    public void ResetLine()
    {
        line1.positionCount = 0;
        line1.positionCount = positionCount;

        line2.positionCount = 0;
        line2.positionCount = positionCount;
    }
}
