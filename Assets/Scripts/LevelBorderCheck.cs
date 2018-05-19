using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBorderCheck : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            float z = collision.gameObject.transform.position.z;
            Vector3 location = collision.gameObject.transform.position * -1f;

            collision.gameObject.transform.SetPositionAndRotation(location,
                Quaternion.Euler(0,0,90));
        }
    }
}
