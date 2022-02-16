using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PongPlayerController : MonoBehaviour
{   
    [SerializeField]
    float speed;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PongStats.scorePlayer1 = 0;
        PongStats.scorePlayer2 = 0;
    }

    public void Up(InputAction.CallbackContext context)
    {
        if (context.started) rb.velocity = new Vector2(rb.velocity.x, speed);
        else if (context.canceled) rb.velocity = new Vector2(0,0);
    }

    public void Down(InputAction.CallbackContext context)
    {
        if (context.started) rb.velocity = new Vector2(rb.velocity.x, -speed);
        else if (context.canceled) rb.velocity = new Vector2(0,0);
    }
}
