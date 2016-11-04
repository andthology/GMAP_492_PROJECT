using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{
    public float spawnTimer;
    public GameObject enemy;
    

    private float timeTillSpawn;


	// Use this for initialization
	void Start ()
    {
        timeTillSpawn = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeTillSpawn -= Time.deltaTime;

        if (timeTillSpawn <= 0f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);

            timeTillSpawn = spawnTimer;
        }
	}
}
