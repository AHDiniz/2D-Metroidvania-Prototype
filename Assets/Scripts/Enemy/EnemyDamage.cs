using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int lifePoints;
    [SerializeField] private bool hasHitAnim = false;
    [SerializeField] private string playerAtkBoxTag = "";
    [SerializeField] private float cooldownTime = .5f;
    [SerializeField] private Color damageColor;

    private int currentLife;
    private Color initColor;
    private EnemyMovement movement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int hitTriggerID, lifeParamID;

    private void Start()
    {
        movement = GetComponent<EnemyMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        initColor = spriteRenderer.color;
        currentLife = lifePoints;

        if (hasHitAnim) hitTriggerID = Animator.StringToHash("Hit");
        lifeParamID = Animator.StringToHash("Life");
        animator.SetInteger(lifeParamID, currentLife);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == playerAtkBoxTag)
        {
            HitBox h = trigger.gameObject.GetComponent<HitBox>();
            StartCoroutine(Cooldown(h));
        }
    }

    private IEnumerator Cooldown(HitBox hitbox)
    {
        if (hasHitAnim) animator.SetTrigger(hitTriggerID);
        movement.CanMove = false;
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(cooldownTime);
        movement.CanMove = true;
        spriteRenderer.color = initColor;

        currentLife -= hitbox.Damage;
        animator.SetInteger(lifeParamID, currentLife);
    }

    public void Kill()
    {
        this.gameObject.SetActive(false);
    }
}
