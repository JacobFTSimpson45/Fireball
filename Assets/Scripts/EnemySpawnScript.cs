using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public Transform enemyList;
    public GameObject enemyPrefab;
    public GameObject player;
    public Transform spawnpoint;
    public bool isSpawning;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = true;
        StartCoroutine(EnemySpawner());
    }
    private void Update()
    {
        Health playerHP = player.GetComponent<Health>();
        if (playerHP.health <= 0)
        {
            isSpawning = false;
            StopAllCoroutines();
        }
    }
    IEnumerator EnemySpawner()
    {
        while (isSpawning == true)
        {
            Instantiate(enemyPrefab, spawnpoint.position, spawnpoint.rotation, enemyList);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
