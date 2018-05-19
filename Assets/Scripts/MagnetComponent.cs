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

	// Use this for initialization
	void Start () {
        IsActive = false;	
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
                if (go.GetComponent<Rigidbody2D>() == null)
                {
                    Rigidbody2D body = go.AddComponent<Rigidbody2D>();
                    body.gravityScale = 0f;
                    body.mass = 20f;
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
    }
}
