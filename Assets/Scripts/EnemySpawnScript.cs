using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, Random.Range(2,4));
    }

    public void Spawn()
    {
        Vector3 enemyPosition = new Vector3(Random.Range(-2, 2),7,0);
        Instantiate(enemyPrefab, enemyPosition, enemyPrefab.transform.rotation);
    }
}
