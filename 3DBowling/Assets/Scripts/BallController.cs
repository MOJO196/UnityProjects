using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;
    Vector3 dir = new Vector3(0.1f, 0.0f, 0.0f);

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        for (;;)
        {
            
            if (Input.GetButtonDown("Horizontal"))
                rb.position -= dir;
            else if (Input.GetButtonDown("Horizontal"))
                rb.position += dir;
            else if (Input.GetButtonDown("Fire1"))
                break;
        }
        rb.velocity = speed * new Vector3(0.0f, 0.0f, 1.0f);
    }
}
