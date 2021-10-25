using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerController))]
public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int lifePoints;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float knockbackForce;
    [SerializeField] private Color damageColor;
    [SerializeField] private string damageTag;
    [SerializeField] private Image healthBar;

    private int currentPoints;
    private Color initColor;
    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;
    private PlayerController controller;

    void Start()
    {
        currentPoints = lifePoints;
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();

        initColor = spriteRenderer.color;
    }

    void Update()
    {
        healthBar.fillAmount = currentPoints / lifePoints;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == damageTag)
        {
            Vector2 direction = new Vector2();
            if (col.transform.position.x > transform.position.x) direction = new Vector2(-1, 0);
            else if (col.transform.position.x < transform.position.x) direction = new Vector2(1, 0);
            StartCoroutine(Damage(direction));
        }
    }

    private IEnumerator Damage(Vector2 direction)
    {
        spriteRenderer.color = damageColor;
        controller.CanMove = false;
        rb2D.velocity = direction * knockbackForce;
        --currentPoints;
        yield return new WaitForSeconds(cooldownTime);
        spriteRenderer.color = initColor;
        controller.CanMove = true;
    }
}
