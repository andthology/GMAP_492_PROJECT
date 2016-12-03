using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int damage;
    public Vector3 targetPosition;
    //public Transform muzzlepoint;
	public int points;

	private ScoreControl scoreScript;


	void Start()
	{
        //Locating the gameObject holding the ScoreManager script in the scene
		scoreScript = GameObject.Find ("GameManager").GetComponent<ScoreControl> ();	
	}


	// Update is called once per frame
	void Update ()
    {
        //moving the enemy gameObject to a Vector3 with (starting point, end point, movement speed)
        transform.position = Vector3.MoveTowards(transform.position, targetPosition/*muzzlepoint.position*/, speed * Time.deltaTime); 
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);

			scoreScript.IncreaseScore(points);
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
    }
}
