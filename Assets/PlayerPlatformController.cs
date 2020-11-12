using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPlatformController : MonoBehaviour
{
    public float moveSpeed = 5;
    private float actualSpeed;
    public float jumpHeight = 5;
    public Transform model;
    public Rigidbody2D theRb;
    public float speedMultilpy = 1.5f;
    public float fallMultiply = 0.3f;

    public float hangeTime = .2f;
    public float hangeCount;

    public float jumpBufferLenght = .1f;
    public float jumpBufferCount;

    public Transform groundCheck;
    public bool isGrounded;
    public LayerMask ground;
    public float groundCheckRadius = .1f;

    public Animator anim;


    private void Update()
    {
        //Movimiento
        float x = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.Q))
        {
            actualSpeed = moveSpeed * speedMultilpy;
        }
        else
        {
            actualSpeed = moveSpeed; 
        }

        theRb.velocity = new Vector2(actualSpeed * x, theRb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(theRb.velocity.x));
        //Salto

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        anim.SetBool("Jump", !isGrounded);

        if (isGrounded)
        {
            hangeCount = hangeTime;
        }
        else
        {
            if (hangeCount > -3)
            {
                hangeCount -= Time.deltaTime;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLenght;
        }
        else
        {
            if(jumpBufferCount > -3)
            {
                jumpBufferCount -= Time.deltaTime;
            }
        }

        if(jumpBufferCount >= 0 && hangeCount > 0)
        {
            theRb.velocity = new Vector2(theRb.velocity.x, jumpHeight);
            jumpBufferCount = 0;
            hangeCount = 0;
        }
        if(Input.GetButtonUp("Jump") && theRb.velocity.y >0)
        {
            theRb.velocity = new Vector2(theRb.velocity.x, theRb.velocity.y * fallMultiply);
        }
        //flip
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            model.DORotate(new Vector3(0, -180, 0), 0.5f);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            model.DORotate(new Vector3(0, 0, 0), 0.5f);
        }
        
        

    }

}
