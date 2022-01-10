using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : Buttons
{
    [SerializeField]
    int backLocation;
    
    public override void OnClick()
    {
        SceneLoader.instance.SetScene(backLocation);
    }
}
