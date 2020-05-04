using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Ground Movement")]
    [Tooltip("Movement speed in tiles per second (1 tile = 1 meter)")]
    [SerializeField]
    private float speed;

    [Header("Air Movement")]
    [Tooltip("The Up ward force applied when player jumps.")]
    [Range(0f, 10f)]
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D playerRigibody;
    private bool isFacingRight = true;
    private bool isOnGround = true;
    new private Collider2D collider;
    private RaycastHit2D[] hits = new RaycastHit2D[16];
    private float groundDistantceCheck = 0.05f;
    private Animator animator;
    private float horizontalInput = 0;
    private bool isJumpPressed = false;

    void Start()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput += Input.GetAxis("Horizontal");
        isJumpPressed = isJumpPressed || Input.GetButtonDown("Jump");
     
    }

    void FixedUpdate()
    {
        float xVelocity = horizontalInput * speed;
        playerRigibody.velocity = new Vector2(xVelocity, playerRigibody.velocity.y);

        if ((isFacingRight && horizontalInput < 0) ||
            (!isFacingRight && horizontalInput > 0))
        {
            Flip();
        }

        int numHits = collider.Cast(Vector2.down, hits, groundDistantceCheck);
        isOnGround = numHits > 0;

        Vector2 rayStart = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        Vector2 rayDirection = Vector2.down;
        Debug.DrawRay(rayStart, rayDirection, Color.red, 1f);


        if (isJumpPressed && isOnGround)
        {
            playerRigibody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        animator.SetFloat("xSpeed", Mathf.Abs(playerRigibody.velocity.x));
        animator.SetFloat("yVelocity", playerRigibody.velocity.y);
        animator.SetBool("isOnGround", isOnGround);

        ClearInput();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 10 : -10;
        transform.localScale = scale;
    }

    private void ClearInput()
    {
        horizontalInput = 0;
        isJumpPressed = false;
    }
}
