using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJamStateMachine 
{
    public PlayerJamState currentState { get; private set; }

    public void Initialize(PlayerJamState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerJamState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
