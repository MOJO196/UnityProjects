using UnityEngine;
using UnityEngine.UI;

public class SpawnObjectOnClick : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    [SerializeField]
    float zPos;
    Vector3 mousePos;
    Vector3 objectPos;

    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = zPos;
            Instantiate(obj, objectPos, Quaternion.identity);
        }
    }
}
