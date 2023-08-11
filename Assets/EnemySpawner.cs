using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnDelay = .1f;

    int spawnedEnemies;
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    // Update is called once per frame
    IEnumerator spawnEnemies()
    {
        Vector3 Pos = new Vector3(6f, 0f, Random.Range(-2.5f, 2.5f));
        Instantiate(enemyPrefab, Pos, Quaternion.identity) ;
        spawnedEnemies++;
        if(spawnedEnemies >= 5 && spawnDelay >= .2f)
        {
            spawnedEnemies = 0;
            spawnDelay -= .1f;
        }    
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(spawnEnemies());
    }
}
