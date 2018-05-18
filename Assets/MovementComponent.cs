using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    public float Speed = 1.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movmentDirection = Vector3.zero;
		if (Input.GetKey(KeyCode.W))
        {
            movmentDirection.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movmentDirection.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movmentDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movmentDirection.x = 1;
        }
        
        gameObject.transform.Translate(movmentDirection * Speed * Time.deltaTime);


        bool doSim = false;
        if (Input.GetKey(KeyCode.Space))
        {
            doSim = true;
        }

        gameObject.GetComponent<Rigidbody2D>().simulated = doSim;
	}
}
