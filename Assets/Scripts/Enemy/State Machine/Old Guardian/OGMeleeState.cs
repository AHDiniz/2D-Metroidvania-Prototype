using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGMeleeState : State
{
    [SerializeField] private string meleeParamName;

    public override void Init()
    {
        animator.SetTrigger(meleeParamName);
    }
}
