using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float attackMoveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCastRadius;
    [SerializeField] private Transform jumpCastPosition;
    [SerializeField] private LayerMask jumpDetectionLayer;

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    private Vector2 dirInput;
    private float initGravityScale, initVelocityY;
    private bool grounded;
    private bool isAttacking;
    private bool canMove = true;

    public Vector2 DirInput { get => dirInput; }
    public bool Grounded { get => grounded; }
    public bool CanMove { get => canMove; set => canMove = value; }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        initGravityScale = rb2D.gravityScale;
    }

    void Update()
    {
        dirInput.x = Input.GetAxis("Horizontal");

        if (dirInput.x > 0) transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (dirInput.x < 0) transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(jumpCastPosition.position, jumpCastRadius, jumpDetectionLayer);

        if (canMove) rb2D.velocity = new Vector2(dirInput.x * walkSpeed, rb2D.velocity.y);

        if (grounded && Input.GetButton("Jump"))
        {
            rb2D.velocity = Vector2.up * jumpForce;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(jumpCastPosition.position, jumpCastRadius);
    }

    public void StartAttack()
    {
        canMove = false;
        if (!grounded) rb2D.gravityScale = 0;
        initVelocityY = rb2D.velocity.y;
        rb2D.velocity = new Vector2(transform.localScale.x * attackMoveSpeed, 0);

    }

    public void EndAttack()
    {
        canMove = true;
        rb2D.gravityScale = initGravityScale;
        rb2D.velocity = new Vector2(0, initVelocityY);
    }
}
