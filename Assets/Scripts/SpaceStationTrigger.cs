using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationTrigger : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10) //10 = AttachedToPlayer
        {
            GameLogic.Instance.ReportScrapDelivered(1);
            GameObject.Destroy(collision.gameObject);
        }
    }
}
