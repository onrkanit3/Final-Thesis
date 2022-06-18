using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : CharacterBaseState
{
    public override void EnterState(CharacterStateManager characterStateManager)
    {
        base.EnterState(characterStateManager);
        Debug.Log("Entered To Run State");
    }

    public override void UpdateState(CharacterStateManager characterStateManager)
    {
        if (Time.time - stateEnteredTime > 5)
        {
            stateEnteredTime = Time.time;
            characterStateManager.SwitchState(characterStateManager.sleepState);
        }
        Debug.Log("Character is running");
        Debug.Log("Run Animation is playing");
        Debug.Log("Transform changes");
    }
}
