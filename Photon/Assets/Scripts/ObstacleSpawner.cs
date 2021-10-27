using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstacle;
    [SerializeField] private float spawnTime;
    
    
    private Pool obstaclePool;
    private float nextSpawn;

    private void Start()
    {
        obstaclePool = new Pool(obstacle);
        nextSpawn = spawnTime;
    }

    private void Update()
    {
        nextSpawn = Mathf.Min(nextSpawn + Time.deltaTime, spawnTime);
        if (nextSpawn >= spawnTime)
            Spawn();
    }

    private void Spawn()
    {
        GameObject obstacle = obstaclePool.GetObject();
        obstacle.transform.position = transform.position;
        obstacle.SetActive(true);

        nextSpawn = 0;

    }

}
