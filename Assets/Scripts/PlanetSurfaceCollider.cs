using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSurfaceCollider : MonoBehaviour {

    const int SpaceTrashLayer = 9;
    const int AttachToPlayerLayer = 10;

    public GameObject ExplosionSFX;


    void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D thisCollider = this.GetComponent<Collider2D>();
        if ( (other.gameObject.layer == SpaceTrashLayer && !thisCollider.usedByEffector) || other.gameObject.layer == AttachToPlayerLayer)
        {
            if (ExplosionSFX != null)
            {
                Instantiate(ExplosionSFX);
            }

            Destroy(other.gameObject);
        }
    }
}
