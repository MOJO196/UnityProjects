using UnityEngine;

public class RandomColor : MonoBehaviour
{   
    void Start() 
    {
        gameObject.GetComponent<Renderer>().material.color = getRandomColor();
    }

    public Color getRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
}
