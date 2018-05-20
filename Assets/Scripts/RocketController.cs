using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public float spawnTimer = 5;

	private float time;
	private float alertTime;
	public float alertTimeFactor = 0.5f;
	public GameObject rocketPrefab;
	private GameObject rocket;
	public GameObject rocketAlarmPrefab;
	private GameObject rocketAlarm;

	private Vector2 rocketSpawn;
	private Quaternion rot;

	private bool rocketReady = false;
	private bool flag = true;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {


		alertTime -= Time.deltaTime;
		time += Time.deltaTime;

		if (alertTime <= 0 && flag == true) {
			rocketReady = true;
			flag = false;
		}

		if (rocketReady) {

			calcRocketPosition ();
			rocketAlarm = Instantiate (rocketAlarmPrefab, rocketSpawn, rot) as GameObject;
			rocketReady = false;

			}

		if (time >= spawnTimer) {
			Destroy (rocketAlarm);
			rocket = Instantiate (rocketPrefab, rocketSpawn, rot) as GameObject;
			time = 0;
			spawnTimer = Random.Range (20, 35);
			alertTime = (spawnTimer*alertTimeFactor);
			flag = true;




		}
	

}


	private void calcRocketPosition(){
		rocketSpawn = new Vector3(Random.Range(-10f, 10f),Random.Range(-10f,10f));
		rot = Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)));

	}

}