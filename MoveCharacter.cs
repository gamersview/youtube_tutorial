using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    [Space(10f)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float jumpheight = 3f;
    
    Vector3 velocity;
    private bool isGrounded;
    
    void Update()
    {
        MovePlayer();
        Jump();
    }

    

    private void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontalMove + transform.forward * verticalMove;
        _controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
    }
}
