using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunJamState : GroundJamState
{
    public RunJamState(Player_Jam _player, PlayerJamStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        if(xInput==0)stateMachine.ChangeState(player.idleJamState);
        AudioManager.instance.PlaySFX(19, null);
    }
}
