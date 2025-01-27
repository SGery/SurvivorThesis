using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // Frame rate dependent
    void Update()
    {
        InputManagement();
    }

    // Fixed update for movement physics calculation
    // Frame rate independent
    private void FixedUpdate()
    {
        Move();
    }

    // Handle inputs
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;


        // Store last input before stop to avoid right-facing
        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
        }

        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
        }
    }

    // Handle movements
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
