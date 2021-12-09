using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PongPlayerControll : MonoBehaviour
{   
    public float speed;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Up(InputAction.CallbackContext context)
    {
        if (context.started)
            rb.velocity = new Vector2(rb.velocity.x, speed);
        else if (context.canceled)
            rb.velocity = new Vector2(0,0);
    }

    public void Down(InputAction.CallbackContext context)
    {
        if (context.started)
            rb.velocity = new Vector2(rb.velocity.x, -speed);
        else if (context.canceled)
            rb.velocity = new Vector2(0,0);
    }
}
