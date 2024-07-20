using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jam : MonoBehaviour,IConnection
{
    public Rigidbody2D rb { get; private set; }
    
    public Animator anim { get; private set; }
    public float speed = 10;
    public float jumpForce = 10;
    private FixedJoint2D fixedJoint;
    public IdleJamState idleJamState { get; private set; }
    public JumpJamState jumpJamState { get; private set; }
    public RunJamState runJamState { get; private set; }
    public PlayerJamStateMachine stateMachine;
    private bool isConnect;

    private void Awake()
    {
        stateMachine = new PlayerJamStateMachine();
        idleJamState = new IdleJamState(this,stateMachine,"Idle");
        jumpJamState = new JumpJamState(this, stateMachine, "Jump");
        runJamState = new RunJamState(this, stateMachine, "Run");
        rb = GetComponent<Rigidbody2D>();
        fixedJoint = GetComponent<FixedJoint2D>();
        anim = GetComponent<Animator>();
        fixedJoint.connectedBody = rb;
    }
    void Start()
    {
        stateMachine.Initialize(idleJamState);
    }
    void Update()
    {
        stateMachine.currentState.Update();
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.instance.PlaySFX(0, null);
        }
        if (Input.GetKeyUp(KeyCode.E)&&isConnect)
        {
            Disconnect();
        }
        
    }
    public void Connect(GameObject any)
    {
        fixedJoint.connectedBody = any.GetComponent<Rigidbody2D>();
        isConnect = true;
    }

    public void Disconnect()
    {
        fixedJoint.connectedBody = rb;
        isConnect = false;
    }
    

    
}
