using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    [SerializeField]
    GameObject img;
    
    void Awake() 
    {
        img.GetComponent<Image>().color = Color.red;
    }
}
