using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToggle : MonoBehaviour {

    const string TrashLayer = "Trash";
    const string AttachToPlayerLayer = "AttachedToPlayer";

    public Collider2D collision;

	// Use this for initialization
	void Start () {
        collision = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.tag == TrashLayer)
        {
           collision.enabled = true;
        }
        else
        {
          collision.enabled = false;
        }
	}
}
