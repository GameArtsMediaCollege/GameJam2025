using System.Collections;
using UnityEngine;

public class EnemyLifeSupport : MonoBehaviour
{
    public int lifecount = 3;

    [SerializeField] Animator animator;
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
            animator.SetBool("EnemyHit", true);
            CheckLife();
        }
    }

    private void CheckLife()
    {
        lifecount--;
        if(lifecount == 0)
        {
            EnemyDeath();
        }
    }
    void EnemyDeath()
    {
        animator.SetBool("deadBool", true);
        StartCoroutine(WaitDeathAnim());
    }
    IEnumerator WaitDeathAnim() 
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
