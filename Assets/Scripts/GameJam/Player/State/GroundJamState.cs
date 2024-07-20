using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundJamState : PlayerJamState
{
    public GroundJamState(Player_Jam _player, PlayerJamStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpJamState);
        }
        Flip();
    }

    private void Flip()
    {
        if (xInput != 0) player.transform.localScale = new Vector3(xInput, 1, 1);
    }
}
