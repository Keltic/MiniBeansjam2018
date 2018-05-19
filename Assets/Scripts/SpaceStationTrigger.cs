using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationTrigger : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) //10 = AttachedToPlayer
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                GameLogic.Instance.ReportScrapDelivered(rb.mass);
                GameObject.Destroy(collision.gameObject);
            }
        }
    }
}
