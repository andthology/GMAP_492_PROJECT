using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Vector3 targetPosition;
    


	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
