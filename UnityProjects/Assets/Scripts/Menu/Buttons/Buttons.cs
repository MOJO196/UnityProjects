using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public virtual void OnClick()
    {
        Debug.Log("You dont want to call this class!");
        return;
    }
}
