using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public float spawnTimer = 5;
	public float alertTimer = 5;
	private float time;
	private float alertTime;
	public GameObject rocketPrefab;
	private GameObject rocket;
	private GameObject rocketAlarmPrefab;
	private GameObject rocketAlarm;
	public GameObject planet;

	private Vector3 rocketSpawn;
	private Vector2 planetPosition;
	private Quaternion rot;
	// Use this for initialization
	void Start () {
		planetPosition = new Vector2();
		planetPosition = planet.transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
		
		alertTime += Time.deltaTime;
		time += Time.deltaTime;
		if (alertTime  == spawnTimer/3) {

			calcRocketPosition ();
			rocketAlarm = Instantiate (rocketAlarmPrefab, rocketSpawn) as GameObject;

			}

		if (time >= spawnTimer) {
			Destroy (rocketAlarm);
			rocket = Instantiate (rocketPrefab, rocketSpawn, rot) as GameObject;
			time = 0;
			spawnTimer = Random.Range (8, 15);


		}
	

}


	private void calcRocketPosition(){
		rocketSpawn = new Vector3(planetPosition.x + Random.Range(-10f, 10f), planetPosition.y + Random.Range(-10f,10f),0);
		rot = Quaternion.Euler (0, 0, Random.Range (0, 360));

	}

}