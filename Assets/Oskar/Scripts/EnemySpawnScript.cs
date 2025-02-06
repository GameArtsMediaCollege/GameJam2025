using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float spawnInterval;
    bool isWaiting = false;

    private void Start()
    {
        SpawnEnemy();
    }
    private void Update()
    {

        if (!isWaiting)
        {
            SpawnEnemy();
            StartCoroutine(WaitBeforeSpawning());
        }
    }

    IEnumerator WaitBeforeSpawning()
    {
        isWaiting = true;
        yield return new WaitForSeconds(spawnInterval);
        isWaiting = false;
    }


    void SpawnEnemy()
    {
        GameObject newEnemy;
        newEnemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }


}
