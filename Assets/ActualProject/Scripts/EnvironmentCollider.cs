using UnityEngine;
using System.Collections;

public class EnvironmentCollider : MonoBehaviour
{
    public GameObject mesh1;
    //public GameObject mesh2;
    //public GameObject mesh3;
    public float offsetForce;

    //private Collider myCollider;
    //private GameObject myObject;

	// Use this for initialization
	void Start ()
    {
        //myCollider = GetComponent<Collider>();
        //myObject = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag ("Bullet"))
        {
            float bulletX = other.gameObject.transform.position.x;
            float bulletY = other.gameObject.transform.position.y;
            float bulletZ = other.gameObject.transform.position.z;
            Vector3 bulletPos = new Vector3(bulletX, bulletY, bulletZ);
            Destroy(other.gameObject);

            Instantiate(mesh1, bulletPos, Quaternion.identity);

            mesh1.GetComponent<Rigidbody>().AddForce(bulletPos * offsetForce);
        }
    }
}
