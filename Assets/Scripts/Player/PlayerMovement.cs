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


    void Start()
    {

    }

    void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Flip();
        }
    }

    public void FaceOn(Interactable newTarget)
    {
        target = newTarget.transform;
        if (isFacingRight && target.position.x < transform.position.x || !isFacingRight && target.position.x > transform.position.x)
        {
            Flip();
        }
    }


    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
