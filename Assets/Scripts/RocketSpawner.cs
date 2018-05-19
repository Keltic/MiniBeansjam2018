using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public GameObject planet;
	public Vector3 vel = new Vector3 (10, 0, 0);


    // Use this for initialization
    void Start()
    {
        Vector2 planetPosition = new Vector2();
        planetPosition = planet.transform.position;
       
        //  this.gameObject.transform.position = new Vector2(planetPosition.x + planetRadius/2, planetPosition.y);
		this.gameObject.transform.position = new Vector2(planetPosition.x + Random.Range(-10f, 10f), planetPosition.y + Random.Range(-10f,10f));



    }



    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(vel, ForceMode2D.Impulse);



    }
}
