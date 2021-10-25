using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speedMagnitude;
    [SerializeField] private float damage;

    private float direction;
    private int deathParamID;
    private bool canMove = true;

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float Damage { get => damage; }
    public float Direction { get => direction; set => direction = Mathf.Sign(value); }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        deathParamID = Animator.StringToHash("Death");
    }

    void Update()
    {
        spriteRenderer.flipX = direction <= 0;
        if (canMove) rb2D.velocity = new Vector2(direction * speedMagnitude, rb2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        animator.SetBool(deathParamID, true);
        rb2D.velocity = new Vector2(0, 0);
        canMove = false;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
