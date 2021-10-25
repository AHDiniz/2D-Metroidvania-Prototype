using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyMovement
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float groundDetectionDist;
    [SerializeField] private Vector2 wallBoxDetectionSize;
    [SerializeField] private Transform groundDetection, leftWallDetect, rightWallDetect;
    [SerializeField] private LayerMask groundLayer;

    private float velocityX;

    protected override void Init()
    {
        velocityX = walkSpeed;
    }

    protected override void Tick()
    {
        Collider2D col = Physics2D.OverlapCircle(groundDetection.position, groundDetectionDist, groundLayer);
        Collider2D leftCol = Physics2D.OverlapBox(leftWallDetect.position, wallBoxDetectionSize, 0, groundLayer);
        Collider2D rightCol = Physics2D.OverlapBox(rightWallDetect.position, wallBoxDetectionSize, 0, groundLayer);

        if (col == null || leftCol != null || rightCol != null)
        {
            velocityX *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    protected override void Move()
    {
        rb2D.velocity = new Vector2(canMove ? velocityX : 0, rb2D.velocity.y);
    }
}
