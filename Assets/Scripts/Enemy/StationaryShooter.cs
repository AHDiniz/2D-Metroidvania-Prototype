using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StationaryShooter : EnemyMovement
{
    [SerializeField] private float shootingRate;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform left, right;

    private Animator animator;
    private Vector3 shooter;

    private int attackParamID;
    private bool canShoot = true;

    protected override void Init()
    {
        animator = GetComponent<Animator>();

        attackParamID = Animator.StringToHash("Attack");
    }

    protected override void Tick()
    {
        if (canMove && spriteRenderer.isVisible)
        {
            if (playerPosition.position.x > transform.position.x)
            {
                shooter = right.position;
                spriteRenderer.flipX = false;
            }
            else
            {
                shooter = left.position;
                spriteRenderer.flipX = true;
            }

            if (canShoot) StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        canShoot = false;
        animator.SetTrigger(attackParamID);
        yield return new WaitForSeconds(shootingRate);
        canShoot = true;
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab) as GameObject;
        projectile.transform.position = shooter;
        Projectile p = projectile.GetComponent<Projectile>();
        if (p != null)
        {
            if (shooter == left.position) p.Direction = -1;
            else p.Direction = 1;
        }
    }
}
