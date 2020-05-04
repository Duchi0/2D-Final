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
    private bool isJumping;
    private bool isFacingRight = true;

    void Start()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        playerRigibody.velocity = new Vector2(xVelocity, playerRigibody.velocity.y);

        if((isFacingRight && horizontalInput < 0) ||
            (!isFacingRight && horizontalInput > 0))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 10 : -10;
        transform.localScale = scale;
    }
}
