using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    float strength;
    [SerializeField]
    GameObject point;
    float nDistance;

    void OnTriggerStay2D(Collider2D other)
    {
        nDistance = ((Mathf.Abs(point.transform.position.x - other.transform.position.x) + Mathf.Abs(point.transform.position.y - other.transform.position.y)) / 2);

        other.GetComponent<Rigidbody2D>().velocity += new Vector2(
            (strength * (Mathf.Cos(gameObject.transform.localEulerAngles.z * Mathf.Deg2Rad)) * (nDistance * (strength / (5.3684f * gameObject.transform.localScale.x)))), 
            (strength * (Mathf.Sin(gameObject.transform.localEulerAngles.z * Mathf.Deg2Rad)) * (nDistance * (strength / (5.3684f * gameObject.transform.localScale.x)))));
    }
}

// - nDistance * (strength * 0.01f)
// - nDistance * (strength * 0.01f)

// 13.421