using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawning : MonoBehaviour
{
    public Text waveText;
    public float spawnTimer;
    public GameObject enemyA;
    public GameObject enemyB;
    public Transform[] spawnPoints;      //array of spawnpoints enemies can spawn from

    private bool canSpawn = false;
    private float timeTillSpawn;
    private GameObject enemy;
    private int[] enemyType;


	// Use this for initialization
	void Start ()
    {
        enemy = enemyA;
        timeTillSpawn = 0f;
	}
	


	// Update is called once per frame
	void Update ()
    {
        if (canSpawn != true)
        {
            return;
        }
        else
        {
            timeTillSpawn -= Time.deltaTime;

            if (timeTillSpawn <= 0)
            {
                RandomSpawn();

                timeTillSpawn = spawnTimer;
            }

            EnemyChance();
        }
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

        if (chance >= 6)
        {
            enemy = enemyB;
        }
        else
        {
            enemy = enemyA;
        }
    }



    void RoundDelay()
    {
        canSpawn = true;

        waveText.text = "";
    }



    public void ResetSpawn(int wave)
    {
        float roundDelay = 3f;

        canSpawn = false;

        if (wave == 1)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4 }; //no chance
        }
        else if (wave == 2)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4, 5, 6}; //14% chance
            spawnTimer -= 0.5f; //1 second
        }
        else if (wave == 3)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }; //25% chance
            //1 second
        }
        else if (wave == 4)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; //30% chance
            spawnTimer -= 0.25f; //0.75 second
        }
        else if (wave == 5)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //40% chance
            spawnTimer -= 0.25f; //0.5 second
        }
        else if (wave == 6)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; //45% chance
        }
        else if (wave > 6)
        {
            enemyType = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }; //50% chance
        }

        waveText.text = "Wave " + wave.ToString();

        Invoke("RoundDelay", roundDelay);
    }
}
