using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public CharacterBaseState currentState;
    public IdleState idleState = new IdleState();
    public RunState runState = new RunState();
    public SleepState sleepState = new SleepState();

    private void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CharacterBaseState characterBaseState)
    {
        currentState = characterBaseState;
        characterBaseState.EnterState(this);
    }
}
