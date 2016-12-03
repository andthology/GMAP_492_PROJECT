using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{
    public int wave;
    public float spawnTimer;
    public GameObject enemyA;
    public GameObject enemyB;
    public Transform[] spawnPoints;      //array of spawnpoints enemies can spawn from
    
    private float timeTillSpawn;
    private GameObject enemy;
    private int[] enemyType;


	// Use this for initialization
	void Start ()
    {
        wave = 1;
        enemy = enemyA;
        timeTillSpawn = 0f;

        enemyType = new int[]{0,1,2,3,4,5,6,7,8,9};
	}
	

	// Update is called once per frame
	void Update ()
    {
        timeTillSpawn -= Time.deltaTime;

        if (timeTillSpawn <= 0)
        {
            RandomSpawn();

            timeTillSpawn = spawnTimer;
        }

        EnemyChance();
	}


    void Spawn()
    {
        //spawn an enemy at all spawnpoints at the same time
        Instantiate(enemy, spawnPoints[0].position, Quaternion.identity);

        Instantiate(enemy, spawnPoints[1].position, Quaternion.identity);

        Instantiate(enemy, spawnPoints[2].position, Quaternion.identity);
    }


    void RandomSpawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }


    void EnemyChance()
    {
        int chance = Random.Range(0, enemyType.Length);

        if (chance == 7 || chance == 2)
        {
            enemy = enemyB;
        }
        else
        {
            enemy = enemyA;
        }
    }
}
