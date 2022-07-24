using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    [SerializeField]
    Material material;

    void Start()
    {
        material.color = new Color(Random.Range(0, 255) / 255, Random.Range(0, 255) / 255, Random.Range(0, 255) / 255);
    }
}
