using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;

    public float speed = 10;
    public float jumpForce = 10;
    public float gravity = -20;

    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    public void Movement()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        controller.Move(direction * Time.deltaTime);
    }

    public void Jump()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        direction.y += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            direction.y = jumpForce;
        }
    }
}
