using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHingeJoint : MonoBehaviour
{
    public GameObject ropeSegmentPrefab, Xpositon;
    [SerializeField] int numberOfSegments = 100;
    [SerializeField] Sprite startRope,endRope;
    //private List<HingeJoint2D> joints = new List<HingeJoint2D>();
    void Start()
    {
        List<GameObject> ropeSegments = new List<GameObject>();

        Vector2 startPosition = Xpositon.transform.position;

        for (int i = 0; i < numberOfSegments; i++)
        {
            GameObject newSegment = Instantiate(ropeSegmentPrefab, transform);
            newSegment.transform.position = new Vector2(startPosition.x + i * 0.5f, startPosition.y);
            ropeSegments.Add(newSegment);
            if (i == 0)
            {
                HingeJoint2D joint = newSegment.GetComponent<HingeJoint2D>();
                joint.connectedBody = Xpositon.GetComponent<Rigidbody2D>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = new Vector2(0.5f,0);
            }

            if (i > 0)
            {
                HingeJoint2D joint = newSegment.GetComponent<HingeJoint2D>();
                joint.connectedBody = ropeSegments[i - 1].GetComponent<Rigidbody2D>();
            }
        }

        // Thêm thành phần GetRope và EndRope
        for (int i = 1; i < ropeSegments.Count; i++)
        {
            ropeSegments[i].AddComponent<GetRope>();
        }

        ropeSegments[ropeSegments.Count - 1].AddComponent<EndRope>();

        // Thiết lập sprite cho đầu và cuối của dây
        ropeSegments[0].GetComponentInChildren<SpriteRenderer>().sprite = startRope;
        ropeSegments[ropeSegments.Count - 1].GetComponentInChildren<SpriteRenderer>().sprite = endRope;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
