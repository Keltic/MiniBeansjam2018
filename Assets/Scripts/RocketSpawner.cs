using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour {

 
	public float vel;
	private float time = 0;

	public GameObject boomAnimationPrefab;
	public GameObject boomSoundPrefab;


	    // Use this for initialization
    void Start()
    {
       	vel = Random.Range (10, 50);


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
		GameObject boomSound = Instantiate (boomSoundPrefab) as GameObject;
		Destroy (gameObject);

	
	}


}
