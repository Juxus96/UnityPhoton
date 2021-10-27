using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject coin;
    [SerializeField] private int maxCoins;
    [SerializeField] private float spawnTime;

    private int currentCoins;
    private float nextSpawn;

    private void Start()
    {
        Coin.onCollected += () => currentCoins--;
    }

    private void Update()
    {
        nextSpawn = Mathf.Min(nextSpawn + Time.deltaTime, spawnTime);
        if (nextSpawn >= spawnTime && currentCoins < maxCoins)
            Spawn();
    }

    private void Spawn()
    {
        
        Vector2 pos = spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position;

        Instantiate(coin, pos, Quaternion.identity);
        currentCoins++;
        nextSpawn = 0;
            
    }
}
