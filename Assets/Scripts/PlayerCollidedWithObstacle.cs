using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidedWithObstacle : MonoBehaviour {

    const int PlanetLayer = 13;
    const int SpaceStationLayer = 14;
    public float BounceForce = 2000f;

    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.gameObject.layer == PlanetLayer || 
            collision.otherCollider.gameObject.layer == SpaceStationLayer)
        {
            Vector2 myPos = gameObject.transform.position;
            Vector2 direction = myPos - collision.contacts[0].point;

            Rigidbody2D myBody = collision.otherRigidbody;
            if (myBody)
            {
                myBody.AddForce(direction * BounceForce, ForceMode2D.Impulse);
            }
        }
        
    }
}
