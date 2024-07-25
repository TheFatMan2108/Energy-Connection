using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJamState 
{
    protected PlayerJamStateMachine stateMachine;
    protected Player_Jam player;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerJamState(Player_Jam _player, PlayerJamStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        player.rb.velocity = new Vector2(player.speed * xInput, player.rb.velocity.y);
        player.anim.SetFloat("Vertical", rb.velocity.y);
        Flip();
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
    protected void Flip()
    {
        if (xInput != 0) player.transform.localScale = new Vector3(xInput, 1, 1);
    }
}
