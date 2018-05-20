using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationTrigger : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        //9 = SpaceTrash, 10 = AttachedToPlayer
        if (
            rb != null &&
             (
              collision.gameObject.layer == 10 ||
              (
               collision.gameObject.layer == 9 &&
               rb.velocity != Vector2.zero
              )
             )
            )
        {
            GameLogic.Instance.ReportScrapDelivered(rb.mass);
            GameObject.Destroy(collision.gameObject);
        }
    }
}
