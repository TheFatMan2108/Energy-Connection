using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour,IConnection
{
    private Rigidbody2D rb;
    private float direction;
    [SerializeField] private float speed =10;
    [SerializeField] private float jumpForce = 10;
    private FixedJoint2D fixedJoint;
    private bool isConnect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedJoint = GetComponent<FixedJoint2D>();
        fixedJoint.connectedBody = rb;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKeyUp(KeyCode.E)&&isConnect)
        {
            Disconnect();
        }
    }
    private void FixedUpdate()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction*speed,rb.velocity.y);
        
    }

    public void Connect(GameObject any)
    {
        fixedJoint.connectedBody = any.GetComponent<Rigidbody2D>();
        isConnect = true;
        Debug.Log("Connect");
    }

    public void Disconnect()
    {
        fixedJoint.connectedBody = rb;
        isConnect = false;
        Debug.Log("OK");
    }

   
}
