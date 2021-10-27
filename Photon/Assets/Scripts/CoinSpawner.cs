using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject coin;
    [SerializeField] private int maxCoins;
    [SerializeField] private float spawnTime;

    private int currentCoins;
    private float nextSpawn;
    private Pool coinPool;
    private bool[] usedSpot;

    private void Start()
    {
        Coin.onCollected += () => currentCoins--;
        coinPool = new Pool(coin);
        usedSpot = new bool[spawnPoints.Length];
    }

    private void Update()
    {
        nextSpawn = Mathf.Min(nextSpawn + Time.deltaTime, spawnTime);
        if (nextSpawn >= spawnTime && currentCoins < maxCoins)
            Spawn();
    }

    private void Spawn()
    {
        GameObject coin = coinPool.GetObject();
        coin.transform.position = GetRandomPos();
        coin.SetActive(true);

        currentCoins++;
        nextSpawn = 0;
            
    }

    private Vector2 GetRandomPos()
    {
        int i;
        do
        {
            i = Random.Range(0, spawnPoints.Length);
        } while (usedSpot[i]);

        return spawnPoints[i].transform.position;
    }
}
