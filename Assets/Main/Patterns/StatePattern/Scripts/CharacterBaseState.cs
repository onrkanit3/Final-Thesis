using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    public float stateEnteredTime;

    public virtual void EnterState(CharacterStateManager characterStateManager)
    {
        stateEnteredTime = Time.time;
    }
    public abstract void UpdateState(CharacterStateManager characterStateManager);
}
