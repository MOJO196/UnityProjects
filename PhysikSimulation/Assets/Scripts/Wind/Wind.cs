using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    float strength;
    [SerializeField]
    GameObject point;
    float nDistance, distance;

    void OnTriggerStay2D(Collider2D other)
    {
        distance = Mathf.Sqrt(Mathf.Pow((other.transform.position.x - point.transform.position.x), 2) +
                   Mathf.Pow((other.transform.position.y - point.transform.position.y), 2));
        nDistance = -distance / (11.2f * gameObject.transform.localScale.x) + 1f;

        other.GetComponent<Rigidbody2D>().velocity += new Vector2(
            strength * (Mathf.Cos(gameObject.transform.eulerAngles.z * Mathf.Deg2Rad)),
            strength * (Mathf.Sin(gameObject.transform.eulerAngles.z * Mathf.Deg2Rad)));
    }
}
