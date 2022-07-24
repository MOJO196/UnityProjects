using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planet;
    public uint objCount = 5;
    public Vector4 minRange, maxRange;
    public Vector2 sizeRange;

    void Start()
    {
        Vector3 pos;

        for (int i = 0; i < objCount; i++)
        {
            pos.x = Random.Range(minRange.x, maxRange.x);
            pos.y = Random.Range(minRange.y, maxRange.y);
            pos.z = Random.Range(minRange.z, maxRange.z);

            planet.gameObject.GetComponent<Rigidbody>().mass = Random.Range(minRange.w, maxRange.w);
            planet.gameObject.GetComponent<Transform>().localScale = new Vector3(1, 1, 1) * Random.Range(sizeRange.x, sizeRange.y);

            Instantiate(planet, pos, Quaternion.identity);
        }
    }
}
