using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public float minimumSpawnTime;
    public float maximumSpawnTime;
    public GameObject prefab;

    private void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int spawn = RandomSpawn();
            
            Instantiate(prefab, spawnPoints[spawn].position, spawnPoints[spawn].rotation);

            yield return new WaitForSeconds(SpawnTime());
        }
    }

    private int RandomSpawn()
    {
        return Random.Range(0, spawnPoints.Length);
    }

    private float SpawnTime()
    {
        return Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
    
}
