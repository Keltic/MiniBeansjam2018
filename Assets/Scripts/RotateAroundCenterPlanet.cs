using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCenterPlanet : MonoBehaviour {

    public GameObject CenterPlanet;

    public float Speed;

    private Rigidbody2D body;
    private float dist;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        body.centerOfMass = transform.InverseTransformPoint(Vector3.zero);
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        body.centerOfMass = transform.InverseTransformPoint(Vector3.zero);
        // Further away from center -> move faster, just for fun.
        body.angularVelocity = transform.position.magnitude * 2.5f;


    }
}
