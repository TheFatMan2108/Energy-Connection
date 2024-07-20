using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHingeJoint : MonoBehaviour
{
    [SerializeField] Sprite startRope,endRope;
    private List<HingeJoint2D> joints = new List<HingeJoint2D>();
    void Start()
    {
        joints.AddRange(GetComponentsInChildren<HingeJoint2D>());
        for (int i = 1; i<joints.Count;i++)
        {
            joints[i].connectedBody = joints[i-1].gameObject.GetComponent<Rigidbody2D>();
            joints[i].gameObject.AddComponent<GetRope>();
        }
        
        joints[joints.Count - 1].gameObject.AddComponent<EndRope>();
        joints[1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = startRope;
        joints[joints.Count - 1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = endRope;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
