using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int damage;
    public Vector3 targetPosition;
    //public Transform muzzlepoint;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition/*muzzlepoint.position*/, speed * Time.deltaTime); 
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
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
