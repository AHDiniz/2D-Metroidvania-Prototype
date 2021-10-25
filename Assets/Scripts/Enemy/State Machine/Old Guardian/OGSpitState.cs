using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGSpitState : State
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform shooter;
    [SerializeField] private string spitParamName;

    public override void Init()
    {
        animator.SetTrigger(spitParamName);
    }

    public void Shoot()
    {
        GameObject bomb = Instantiate(bombPrefab, shooter.position, shooter.rotation);
        Bomb b = bomb.GetComponent<Bomb>();
        if (b != null)
        {
            b.Direction = 1;
        }
    }
}
