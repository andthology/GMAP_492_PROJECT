using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int damage;
    //public Transform muzzlepoint;
    public int durability;
	public int points;

    private ParticleSystem explosion;
    private float distanceToTravel;
    private Vector3 targetPosition;
    private ScoreControl scoreScript;


	void Start()
	{
        distanceToTravel = -40f;

        targetPosition = new Vector3(transform.position.x, 0, transform.position.z + distanceToTravel);

        explosion = GetComponent<ParticleSystem>();
        //Locating the gameObject holding the ScoreManager script in the scene
        scoreScript = GameObject.Find("GameManager").GetComponent<ScoreControl>();
    }


	// Update is called once per frame
	void Update ()
    {
        //moving the enemy gameObject to a Vector3 with (starting point, end point, movement speed)
        transform.position = Vector3.MoveTowards(transform.position, targetPosition/*muzzlepoint.position*/, speed * Time.deltaTime); 
	}


    int OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            durability -= 1;

            if (durability <= 0)
            {
                Destroy(gameObject);
                explosion.Play(true);

                scoreScript.IncreaseScore(points);
            }
        }

        else if (other.gameObject.CompareTag("Wall"))
        {
            // Get a reference to a health script attached to the collider we hit
            WallControl health = other.gameObject.GetComponent<WallControl>();

            // If there was a health script attached
            if (health != null)
            {
                // Call the damage function of that script, passing in our enemy damage variable
                health.Damage(damage);
            }

            Destroy(gameObject);
        }
        
        return durability;
    }


}
