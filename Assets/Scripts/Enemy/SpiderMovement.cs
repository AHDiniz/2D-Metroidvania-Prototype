using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : EnemyMovement
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float groundDetectionSize;
    [SerializeField] private Transform downDetect, frontDetect;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 velocity;
    private bool down, prevDown = true;
    private bool front, prevFront = true;

    protected override void Init()
    {
        velocity = Vector2.left * walkSpeed;
    }

    protected override void Tick()
    {
        front = Physics2D.OverlapCircle(frontDetect.position, groundDetectionSize, groundLayer) != null;
        down = Physics2D.OverlapCircle(downDetect.position, groundDetectionSize, groundLayer) != null;

        if (!prevFront && front) transform.rotation = Quaternion.Euler(new Vector3(0, 0, 1) * 90);
        if (!prevDown && down) transform.rotation = Quaternion.Euler(new Vector3(0, 0, 1) * -90);

        velocity = transform.right * -walkSpeed;

        prevDown = down;
        prevFront = front;
    }

    protected override void Move()
    {
        if (canMove) rb2D.velocity = new Vector2(velocity.x, velocity.y);
    }   
}
