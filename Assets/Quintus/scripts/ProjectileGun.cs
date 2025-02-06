using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public GameObject bullet;

    public float shootForce;
    public float upwardForce;

    public float timeBetweenShooting;
    public float spread;
    public float reloadTime;
    public float timeBetweenShots;

    public int magazineSize;
    public int bulletsPerTap;
    public bool allowButtonHold;

    bool shooting;
    bool readyToShoot;
    bool reloading; 

    public Camera fpsCam;
    public Transform attackpoint;

    public bool allowInvoke = true; 

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        shooting = Input.GetKey(KeyCode.Mouse0);

        if(readyToShoot && shooting)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetpoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetpoint = hit.point;
        }
        else
        {
            targetpoint = ray.GetPoint(75);
        }


        Vector3 directionWithoutSpread = targetpoint - attackpoint.position;


        //instantiate the bullet
        GameObject currentbullet = Instantiate(bullet, attackpoint.position, Quaternion.identity);
        currentbullet.transform.forward = directionWithoutSpread.normalized;

        currentbullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentbullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if(allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShots);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true; 
    }
}
