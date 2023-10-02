using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    


    private void SpawnRandomOne()
    {
        int rnd = Random.Range (0, EnemyPrefabs.Length);

        Instantiate(EnemyPrefabs[rnd], new Vector3(37,0,0), EnemyPrefabs[rnd].transform.rotation);

    }
    private void Start()
    {
        InvokeRepeating("SpawnRandomOne", 3.0f, 2.0f);

        SpawnRandomOne();

    }
}
