using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class GetRope : MonoBehaviour
{
    [SerializeField] private LayerMask lmPlayer = 64;
    [SerializeField] private float distance = 0.2f;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    private void Update()
    {
        if (IsRope() == null) return;
        if (IsRope().TryGetComponent(out IConnection player))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.Connect(gameObject);
                AudioManager.instance.PlaySFX(0, null);
            }
        }
    }
    public Transform IsRope() => Physics2D.CircleCast(transform.position, distance, transform.position, distance,lmPlayer)?
        Physics2D.CircleCast(transform.position, distance, transform.position, distance, lmPlayer).transform:null;
}
