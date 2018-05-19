using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSuicide : MonoBehaviour {
	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ani.GetCurrentAnimatorStateInfo (0).IsName("buffer") ) {
			
			Destroy (gameObject);

		}

	}
}
