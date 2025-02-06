using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    public float movSpeed = 10f;
    void Start()
    {
        
    }

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * -movSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
    }
}
