using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public static float halfWidthScreen;
    public static float hightScreen;

    public float speed = 10, jumpforse = 5;
    //select Ground and attach to the Platform
    public LayerMask layer;

    bool faceRight = true;
   
    float inputHorizontalVelosity;

    Rigidbody rb;
    Animator animator;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        halfWidthScreen = Camera.main.aspect * Camera.main.orthographicSize;
        hightScreen = halfWidthScreen * 2 / Camera.main.aspect;
    }

    void FixedUpdate()
    {
        FaceAhead();
        Move();
        Jump();
    }

    void Move()
    {
        inputHorizontalVelosity = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        var moveTo = new Vector2(Mathf.Clamp(rb.position.x + inputHorizontalVelosity, -halfWidthScreen + 2, halfWidthScreen - 2), rb.position.y);
        rb.MovePosition(moveTo);
        
        if (inputHorizontalVelosity > 0 || inputHorizontalVelosity < 0)
            animator.SetBool("Run", true);
        else
            animator.SetBool("Run", false);
    }

    void FaceAhead()
    {
        if (inputHorizontalVelosity > 0 && !faceRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            faceRight = !faceRight;
        }
        else if (inputHorizontalVelosity < 0 && faceRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            faceRight = !faceRight;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpforse, ForceMode.Impulse);
        }

    }

    bool IsGrounded()
    {
        var hit = Physics.Raycast(transform.position, Vector3.down, 1.45f, layer);
        if (hit)
            return true;
        return false;
    }
}
