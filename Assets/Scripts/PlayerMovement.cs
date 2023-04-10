using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public Animator animator;
    private float speed = 7f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    Transform target;

    /*float stoppingDistance = 0.5f;
    private float jumpingPower = 16f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;*/


    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Flip();
        }
   

       /* if (target != null)
        {
            Vector2 movePos = new Vector2(target.position.x + stoppingDistance, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, movePos, speed*Time.);
            
        }*/


        /*if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/

    }

    public void FaceOn(Interactable newTarget)
    {
        target = newTarget.transform;
        if(isFacingRight && target.position.x < transform.position.x || !isFacingRight && target.position.x > transform.position.x)
        {
            Flip();
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    /*private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }*/

    /*public void FollowTarget(Interactable newTarget)
    {
        target = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        target = null;
    }*/
}
