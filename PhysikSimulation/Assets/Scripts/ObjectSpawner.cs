using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner instance;
    public uint tiles;

    [SerializeField]
    GameObject obj;
    [SerializeField]
    float zPos, time;
    [SerializeField]
    bool SpawnObjectOnClick;
    bool duringSpawn;
    Vector3 mousePos, objectPos;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        instance = this;
    }

    void Update()
    {
        if (SpawnObjectOnClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
                objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.z = zPos;
                Instantiate(obj, objectPos, Quaternion.identity);
                tiles++;
            }
        }
        else if (!duringSpawn)
        {
            StartCoroutine(delay(time));
            objectPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), (Random.Range(0, Screen.height))));
            objectPos.z = zPos;
            Instantiate(obj, objectPos, Quaternion.identity);
            tiles++;
        }
    }

    IEnumerator delay(float time)
    {
        duringSpawn = true;
        yield return new WaitForSeconds(time);
        duringSpawn = false;
    }
}
