using UnityEngine;

public class EnemyLifeSupport : MonoBehaviour
{
    public int lifecount = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "bullet")
        {
            Debug.Log("damage taken");
            CheckLife();
        }
    }

    private void CheckLife()
    {
        lifecount--;
        if(lifecount == 0)
        {
            Destroy(gameObject);
        }
    }
}
