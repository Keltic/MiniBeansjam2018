using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

    public GameObject planet;
	public float vel;
	private float time = 0;

	public GameObject boomAnimationPrefab;
	
	    // Use this for initialization
    void Start()
    {
        Vector2 planetPosition = new Vector2();
        planetPosition = planet.transform.position;
       
        //  this.gameObject.transform.position = new Vector2(planetPosition.x + planetRadius/2, planetPosition.y);
		this.gameObject.transform.position = new Vector2(planetPosition.x + Random.Range(-10f, 10f), planetPosition.y + Random.Range(-10f,10f));
		vel = Random.Range (10, 50);
		transform.RotateAround(new Vector3(0,0,1), Random.Range(0,360));


    }

	void LateUpdate(){
		time += Time.deltaTime;
		if (time >= 6) {
			Destroy (gameObject);
			time = 0;
		}

	}
  // Update is called once per frame
    void FixedUpdate()
    {
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*vel, ForceMode2D.Impulse);

    }

	void OnCollisionEnter2D(){
		
		GameObject boom = Instantiate (boomAnimationPrefab) as GameObject;
		boom.transform.position = this.transform.position;
		GameLogic.Instance.ReportRocketCrashed (this.gameObject);
		Destroy (gameObject);

	
	}


}
