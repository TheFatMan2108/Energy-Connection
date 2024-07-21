using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerPoles : MonoBehaviour,IConnection
{
    [SerializeField] private GameObject UIW,Light2D;
    private HingeJoint2D Joint2D;
    [SerializeField] private Color onLight, offLight;
    
    private void Start()
    {
        Joint2D = GetComponent<HingeJoint2D>();
        Joint2D.enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = offLight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EndRope endRope))
        {
            AudioManager.instance.PlaySFX(99, null);
            Connect(endRope.gameObject);
        }
    }

    public void Connect(GameObject any)
    {
        Joint2D.enabled = true;
        Joint2D.connectedBody = any.GetComponent<Rigidbody2D>();
        Light2D.SetActive(true);
        // thong bao win o day
        StartCoroutine(OnWinnner(2f));
        AudioManager.instance.PlaySFX(100, null);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = onLight;
    }

    public void Disconnect()
    {
        Joint2D.enabled = false;
    }
    IEnumerator OnWinnner(float time)
    {
        yield return new WaitForSeconds(time);
        UIW.SetActive(true);
    }
}
