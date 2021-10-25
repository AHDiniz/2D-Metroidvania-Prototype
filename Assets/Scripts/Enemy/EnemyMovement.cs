using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    protected bool canMove = true;
    protected Rigidbody2D rb2D;
    protected SpriteRenderer spriteRenderer;

    public bool CanMove { get => canMove; set => canMove = value; }

    protected virtual void Init() { }
    protected virtual void Tick() { }
    protected virtual void Move() { }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Init();
    }

    void Update()
    {
        Tick();
    }

    void FixedUpdate()
    {
        Move();
    }
}
