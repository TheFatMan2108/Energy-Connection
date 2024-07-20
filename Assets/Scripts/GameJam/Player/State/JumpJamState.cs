using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpJamState : AirJamState
{
    public JumpJamState(Player_Jam _player, PlayerJamStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(player.rb.velocity.y==0)stateMachine.ChangeState(player.idleJamState);
    }
}
