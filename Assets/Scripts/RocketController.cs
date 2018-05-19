using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public float timer = 5;
	private float time;
	public GameObject rocketPrefab;
	private GameObject rocket;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if(time >= timer)
		{

			rocket = Instantiate (rocketPrefab) as GameObject;
			time = 0;

		}

}

}