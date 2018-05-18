using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    public GameObject PlayerGameObject;

    const int SpaceTrashLayer = 9;
    const int AttachToPlayerLayer = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D thisCollider = this.GetComponent<Collider2D>();
        if (other.gameObject.layer == SpaceTrashLayer && !thisCollider.usedByEffector)
        {         
            other.gameObject.layer = AttachToPlayerLayer;
            other.gameObject.transform.SetParent(this.gameObject.transform);

            Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
            body.velocity = Vector2.zero;
            body.Sleep();
            body.WakeUp();
            Destroy(body);
            //body.bodyType = RigidbodyType2D.Static;
            
            PlayerCollider pc = other.gameObject.AddComponent<PlayerCollider>();
            pc.PlayerGameObject = PlayerGameObject;
        }        
    }
}
