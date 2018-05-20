using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour {

    public GameObject[] TrashSpawnPresets;

    public GameObject CenterPlant;

    public Camera Camera;

    public float SpawnTimer = 5;
    public int SpawnStackSize = 5;

    public int InitialSpawnCount = 50;

    public float MinSpawnDistanceFromPlanet = 0.1f;
    public float MaxSpawnDistanceFromPlanet = 9f;

    private bool init = false;
    private float currenTimer;


    // Use this for initialization
    void Start () {
        currenTimer = SpawnTimer;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!init)
        {
            init = true;

            for (int i = 0; i < InitialSpawnCount; ++i)
            {
                SpawnRandomTrash(Vector2.zero, MinSpawnDistanceFromPlanet, MaxSpawnDistanceFromPlanet);
            }
        }

        if (currenTimer > 0f)
        {
            currenTimer -= Time.deltaTime;
        }

        if (currenTimer <= 0f)
        {
            currenTimer = SpawnTimer;

            for (int i = 0; i < SpawnStackSize; ++i)
            {
                SpawnRandomTrash(Vector2.zero, MinSpawnDistanceFromPlanet, MaxSpawnDistanceFromPlanet);
            }
        }
	}

    public void SpawnRandomTrashWithMassFilterAtLocation(Vector2 location, float targetMass, int number, System.Action<GameObject> action)
    {
        Vector2 randomPos = Random.insideUnitCircle;

        float minSpawn = Mathf.Sqrt(CenterPlant.transform.localScale.x) + 5;
        float maxSpawn = minSpawn + 20;
        List<GameObject> massFilteredList = new List<GameObject>();

        for (int i = 0; i < TrashSpawnPresets.Length; ++i)
        {
            if (TrashSpawnPresets[i].GetComponent<Rigidbody2D>().mass == targetMass)
            {
                massFilteredList.Add(TrashSpawnPresets[i]);
            }
        }

        for (int i = 0; i < number; ++i)
        {
            Vector2 spawnPos;
            spawnPos = GetRandomPointInCircle(location, minSpawn, maxSpawn);

            int trashIdx = Random.Range(0, massFilteredList.Count);
            GameObject trash = Instantiate(massFilteredList[trashIdx], gameObject.transform);
            trash.transform.position = new Vector3(spawnPos.x, spawnPos.y, gameObject.transform.position.z);

            trash.transform.Rotate(Vector3.forward, Random.Range(0, 360.0f));
            action(trash);
        }
    }

    public void SpawnRandomTrashAtLocation(Vector2 location, int numTrash = -1)
    {
        int stackSize = numTrash == -1 ? SpawnStackSize : numTrash;
        for (int i = 0; i < stackSize; ++i)
        {
            SpawnRandomTrash(location, 0, 10f);
        }
    }

    void SpawnRandomTrash(Vector2 center, float minRange, float maxRange)
    {
        Vector2 randomPos = Random.insideUnitCircle;

        float minSpawn = Mathf.Sqrt(CenterPlant.transform.localScale.x) + minRange;
        float maxSpawn = minSpawn + maxRange;
        Vector2 spawnPos;
        spawnPos = GetRandomPointInCircle(center, minSpawn, maxSpawn);

        int trashIdx = Random.Range(0, TrashSpawnPresets.Length);
        GameObject trash = Instantiate(TrashSpawnPresets[trashIdx], gameObject.transform);
        trash.transform.position = new Vector3(spawnPos.x, spawnPos.y, gameObject.transform.position.z);

        trash.transform.Rotate(Vector3.forward, Random.Range(0, 360.0f));
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
