using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour {

	private Vector3 direction;
	private Vector3 start;

	public LineRenderer lr;

	// Use this for initialization
	void Start () {
		
		start = transform.position;
		direction = transform.right * 300;
		lr.SetPosition (0, start);
		lr.SetPosition (1, direction);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
