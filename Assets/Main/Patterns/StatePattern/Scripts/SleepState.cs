using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager characterStateManager)
    {
        base.EnterState(characterStateManager);
        Debug.Log("Entered To Sleep State");
    }

    public override void UpdateState(CharacterStateManager characterStateManager)
    {
        if (Time.time - stateEnteredTime > 5)
        {
            characterStateManager.SwitchState(characterStateManager.idleState);
            stateEnteredTime = Time.time;
            return;
        }
        Debug.Log("Character is Sleeping");
        Debug.Log("Sleep Animation is playing");
        Debug.Log("Transform doesn't change");
    }
}