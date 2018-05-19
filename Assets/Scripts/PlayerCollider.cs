using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    public GameObject PlayerGameObject;

    const int SpaceTrashLayer = 9;
    const int AttachToPlayerLayer = 10;

    private Collider2D myCollider;
    private PointEffector2D playerPointEffector;

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (!myCollider)
        {
            myCollider = this.GetComponent<Collider2D>();
        }

        if (!playerPointEffector)
        {
            playerPointEffector = PlayerGameObject.GetComponent<PointEffector2D>();
        }

        if (!playerPointEffector || !playerPointEffector.enabled)
        {
            return;
        }

        if (other.gameObject.layer == SpaceTrashLayer && !myCollider.usedByEffector)
        {         
            other.gameObject.layer = AttachToPlayerLayer;
            other.gameObject.transform.SetParent(PlayerGameObject.transform);

            Destroy(other.gameObject.GetComponent<Rigidbody2D>());

            PlayerCollider pc = other.gameObject.AddComponent<PlayerCollider>();
            pc.PlayerGameObject = PlayerGameObject;
        }        
    }
}
