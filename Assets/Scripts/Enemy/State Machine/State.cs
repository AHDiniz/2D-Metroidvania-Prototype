using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(Animator))]
public class State : MonoBehaviour
{
    protected StateMachine machine;
    protected Animator animator;

    private void Start()
    {
        machine = GetComponent<StateMachine>();
        animator = GetComponent<Animator>();
    }

    public virtual void Init() {}
    public virtual void Tick() {}
    public virtual void Finish() {}
}
