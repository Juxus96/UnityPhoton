using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumps;

    private Vector2 input;
    private Rigidbody2D rb;
    private bool jump;
    private int currentJumps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentJumps = 0;
    }

    private void Update()
    {
        input = Vector2.right * Input.GetAxisRaw("Horizontal") + Vector2.up * Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        // Air control
        rb.velocity = Vector2.right * Mathf.Abs(rb.velocity.x) * input.x + Vector2.up * rb.velocity.y;

        if(Mathf.Abs(rb.velocity.x) < maxSpeed )
            rb.AddForce(input * speed * Time.deltaTime, ForceMode2D.Impulse);


        if(jump && currentJumps < maxJumps)
        {
            rb.velocity -= rb.velocity.y * Vector2.up;
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            jump = false;
        }
        
    }
}
