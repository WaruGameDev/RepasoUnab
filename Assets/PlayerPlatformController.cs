using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPlatformController : MonoBehaviour
{
    [Header("Platform Values")]
    public float moveSpeed = 5;
    private float actualSpeed;
    public float jumpHeight = 5;
    public float speedMultilpy = 1.5f;
    public float fallMultiply = 0.3f;

    [Header("Visuals")]
    public Transform model;
    public Rigidbody2D theRb;
    public Animator anim;

    [Header("Better jumps")]
    public float hangeTime = .2f;
    public float hangeCount;

    public float jumpBufferLenght = .1f;
    public float jumpBufferCount;

    [Header("Detección de piso")]
    public Transform groundCheck;
    public bool isGrounded;
    public LayerMask ground;
    public float groundCheckRadius = .1f;

    [Header("Detección de pared")]
    public bool isByWall;
    public float wallDistance = 0.5f;
    public Vector3 offsetWallRay;
    public float fallSpeedOnWall = -4;


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
            hangeCount -= Time.deltaTime;
           
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLenght;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;

        }

        if(jumpBufferCount >= 0 && hangeCount > 0)
        {
            theRb.velocity = new Vector2(theRb.velocity.x, jumpHeight);
            jumpBufferCount = 0;
            hangeCount = 0;
        }
        if(Input.GetButtonUp("Jump") && theRb.velocity.y >0 && !isByWall)
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
        //wallDetect
        isByWall = Physics2D.Raycast(transform.position + offsetWallRay, model.right, wallDistance, ground);
        Debug.DrawRay(transform.position+ offsetWallRay, model.right * wallDistance, Color.red);

        anim.SetBool("Wall", isByWall && !isGrounded);

        if(isByWall && !isGrounded)
        {
            Vector2 clampVel = theRb.velocity;
            clampVel.y = Mathf.Clamp(clampVel.y, fallSpeedOnWall, Mathf.Infinity);
            theRb.velocity = clampVel;      
            if(Input.GetButtonDown("Jump") && Input.GetAxisRaw("Horizontal") != 0)
            {
                Vector2 vector = model.right;
                theRb.velocity = new Vector2(vector.x *(jumpHeight), jumpHeight);
            }
        }
    }

}
