using System;
using UnityEngine;
using UnityEngine.Video;

public class PlayerControllerWithOutStatePattern : MonoBehaviour
{
    private State currentState;
    private float stateEnteredTime;

    private void Awake()
    {
        currentState = State.Sleep;
        stateEnteredTime = Time.time;
    }

    private void Update()
    {
        switch (currentState)
        {
            // case State.Stop:
            //     if (Time.time - stateEnteredTime > 5)
            //     {
            //         currentState = State.Run;
            //         stateEnteredTime = Time.time;
            //         break;
            //     }
            //     Debug.Log("Stopped");
            //     Debug.Log("Stop Animation is playing");
            //     Debug.Log("Transform doesn't change");
            //     break;
            case State.Run:
                if (Time.time - stateEnteredTime > 5)
                {
                    currentState = State.Sleep;
                    stateEnteredTime = Time.time;
                    break;
                }
                Debug.Log("Character is running");
                Debug.Log("Run Animation is playing");
                Debug.Log("Transform changes");
                break;
            // case State.Fight:
            //     if (Time.time - stateEnteredTime > 5)
            //     {
            //         currentState = State.Sleep;
            //         stateEnteredTime = Time.time;
            //         break;
            //     }
            //     Debug.Log("Character is fighting");
            //     Debug.Log("Fight Animation is playing");
            //     Debug.Log("Transform changes");
            //     break;
            case State.Sleep:
                if (Time.time - stateEnteredTime > 5)
                {
                    currentState = State.Idle;
                    stateEnteredTime = Time.time;
                    break;
                }
                Debug.Log("Character is Sleeping");
                Debug.Log("Sleep Animation is playing");
                Debug.Log("Transform doesn't change");
                break;
            case State.Idle:
                if (Time.time - stateEnteredTime > 5)
                {
                    currentState = State.Run;
                    stateEnteredTime = Time.time;
                    break;
                }
                Debug.Log("Character is Idle");
                Debug.Log("Idle Animation is playing");
                Debug.Log("Transform doesn't change");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum State
{
    Stop,
    Run,
    Fight,
    Sleep,
    Idle
}
