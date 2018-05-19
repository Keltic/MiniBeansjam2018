using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour {

    public GameObject[] TrashSpawnPresets;

    public GameObject CenterPlant;

    public Camera Camera;

    public int InitialSpawnCount = 50;

    public float MinSpawnDistanceFromPlanet = 0.1f;
    public float MaxSpawnDistanceFromPlanet = 9f;

    private bool init = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (!init)
        {
            init = true;

            for (int i = 0; i < InitialSpawnCount; ++i)
            {
                Vector2 randomPos = Random.insideUnitCircle;                

                float minSpawn = Mathf.Sqrt(CenterPlant.transform.localScale.x) + MinSpawnDistanceFromPlanet;
                float maxSpawn = minSpawn + MaxSpawnDistanceFromPlanet;
                Vector2 spawnPos;
                spawnPos = GetRandomPointInCircle(Vector2.zero, minSpawn, maxSpawn);

                int trashIdx = Random.Range(0, TrashSpawnPresets.Length);
                GameObject trash = Instantiate(TrashSpawnPresets[trashIdx], gameObject.transform);
                trash.transform.position = new Vector3(spawnPos.x, spawnPos.y, gameObject.transform.position.z);
            }
        }
	}

    Vector2 GetRandomPointInCircle(Vector2 center, float minRadius, float maxRadius)
    {
        Vector2 result;


        float angle = 2f * Mathf.PI * Random.Range(0, 1f);
        float radius = Mathf.Sqrt(Random.Range(minRadius, maxRadius));

        result.x = radius * Mathf.Cos(angle) + center.x;
        result.y = radius * Mathf.Sin(angle) + center.y;

        return result;
    }
}
