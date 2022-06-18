using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager characterStateManager)
    {
        base.EnterState(characterStateManager);
        Debug.Log("Entered To Idle State");
    }

    public override void UpdateState(CharacterStateManager characterStateManager)
    {
        if (Time.time - stateEnteredTime > 5)
        {
            characterStateManager.SwitchState(characterStateManager.runState);
            stateEnteredTime = Time.time;
            return;
        }
        Debug.Log("Character is Idle");
        Debug.Log("Idle Animation is playing");
        Debug.Log("Transform doesn't change");
    }
}
