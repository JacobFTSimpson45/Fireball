using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnpoint;
    public bool isSpawning;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            while (isSpawning == true)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnTime);
            }
            yield return null;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation);
    }
}
