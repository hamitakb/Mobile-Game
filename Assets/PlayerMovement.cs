using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animatior;

    public float runSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float horizontalMove = 0f;
    bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animatior.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump") && CharacterController2D.m_Grounded)
        {
            isJumping = true;
            animatior.SetBool("Jumping", true);
        }

        if (!CharacterController2D.m_Grounded)
            animatior.SetBool("isGrounded", false);
    }

    public void OnLanding()
    {
        animatior.SetBool("Jumping", false);
        animatior.SetBool("isGrounded", true);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;
    }
}