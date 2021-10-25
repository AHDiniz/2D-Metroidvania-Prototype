using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State initialState;

    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        currentState.Init();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Tick();
    }

    public void ChangeToState(State state)
    {
        currentState.Finish();
        currentState = state;
        currentState.Init();
    }

    public void Reset()
    {
        ChangeToState(initialState);
    }
}
