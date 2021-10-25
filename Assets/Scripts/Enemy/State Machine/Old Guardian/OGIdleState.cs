using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGIdleState : State
{
    [SerializeField] private float distToMelee;
    [SerializeField] private float distToSpit;
    [SerializeField] private float timeToAttack = 4f;
    [SerializeField] private Transform player;
    [SerializeField] private State melee1;
    [SerializeField] private State melee2;
    [SerializeField] private State spit;

    private float timer;

    public override void Tick()
    {
        timer += Time.deltaTime;

        if (timer >= timeToAttack)
        {
            timer = 0f;

            float dist = Vector2.Distance(player.transform.position, transform.position);

            if (dist <= distToMelee)
            {
                float decider = Random.Range(0, 1);

                if (decider < .5f) machine.ChangeToState(melee1);
                else machine.ChangeToState(melee2);
            }
            else if (dist <= distToSpit)
            {
                machine.ChangeToState(spit);
            }
        }
    }
}
