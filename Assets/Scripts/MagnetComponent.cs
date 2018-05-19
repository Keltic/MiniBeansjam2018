using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetComponent : MonoBehaviour {

    const string MagnetActionName = "Magnet";
    const string TrashTag = "Trash";
    const int SpaceTrashLayer = 9;

    public bool IsActive = false;

    public PointEffector2D PointEffector;
    public GameObject TrashContainer;
    public Collider2D ObjectCollider;

    private Rigidbody2D myBody;
    
	// Use this for initialization
	void Start () {
        IsActive = false;
        myBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        IsActive = Input.GetButton(MagnetActionName);

        if (!IsActive && PointEffector.enabled)
        {
            List<GameObject> objectsToReparent = new List<GameObject>();
            for (int ci = 0; ci <  this.gameObject.transform.childCount; ++ci)
            {
                GameObject go = this.gameObject.transform.GetChild(ci).gameObject;
                if(go.tag != TrashTag)
                {
                    continue;
                }
                if (go.transform.parent != null && go.transform.parent.gameObject.layer == go.layer)
                {
                    go = go.transform.parent.gameObject;
                }

                if (go.GetComponent<Rigidbody2D>() == null)
                {
                    Rigidbody2D body = go.AddComponent<Rigidbody2D>();
                    body.gravityScale = 0f;
                    body.mass = 20;
                    Vector2 dir = (gameObject.transform.position - go.transform.position);
                    float veloForce = myBody.velocity.magnitude;
                    body.AddForce( dir * ((myBody.angularVelocity * 0.1f) + (veloForce * -5f)), ForceMode2D.Impulse);
                }
                PlayerCollider pc = go.GetComponent<PlayerCollider>();
                if (pc != null)
                {
                    Destroy(pc);
                }
                go.layer = SpaceTrashLayer;

                objectsToReparent.Add(go);
            }

            foreach(GameObject go in objectsToReparent)
            {
                go.transform.SetParent(TrashContainer.transform);
            }
        }
        PointEffector.enabled = IsActive;

        ObjectCollider.isTrigger = IsActive;

        //Debug.LogWarning("AV:  " + myBody.velocity);
        //myBody.angularVelocity = Mathf.Clamp(myBody.angularVelocity, -50f, 50f);
    }
}
