using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerPoles : MonoBehaviour,IConnection
{
    private HingeJoint2D Joint2D;
    private void Start()
    {
        Joint2D = GetComponent<HingeJoint2D>();
        Joint2D.connectedBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EndRope endRope))
        {
            Connect(endRope.gameObject);
        }
    }

    public void Connect(GameObject any)
    {
        Joint2D.connectedBody = any.GetComponent<Rigidbody2D>();
    }

    public void Disconnect()
    {
        
    }
}
