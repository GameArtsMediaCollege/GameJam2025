using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public Transform bulletspawnpoint;
    public GameObject bulletprefab;
    public float bulletspeed; 


    void Start()
    {
        
    }


    void Update()
    {
        Debug.Log("whats hapenning");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed the space bar");
            GameObject bullet = Instantiate(bulletprefab, bulletspawnpoint.position, bulletspawnpoint.rotation);
            bullet.GetComponent<BulletScript>().movSpeed = bulletspeed;
        }
    }
}
