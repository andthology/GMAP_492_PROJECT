using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BazookaControl : MonoBehaviour
{
    public float shootForce;
    public float fireTime = 0.33f;
    public float projectileLifetime = 5f;
    public Transform muzzlePoint;
    public GameObject projectile;
    public GameObject player;

    private float timeToFire;



    // Use this for initialization
    void Start()
    {
        timeToFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToFire -= Time.deltaTime;

        if (Input.GetMouseButton(0) && (timeToFire <= 0f))
        {
            GameObject currProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
            //Add force to the instantiated projectile / uses .up because bazooka and children are rotated 90, up is effectively forward
            currProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
            Destroy(currProjectile, projectileLifetime);
            timeToFire = fireTime;
        }
    }
    /*
    void ChangeScene()
    {
    if (Input.GetButtonDown("Fire2"))
            {
                ChangeScene();
            }
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float playerZ = player.transform.position.z;
        Vector3 playerPos = new Vector3(playerX, playerY, playerZ);

        SceneManager.LoadScene(1);
    }*/
}
