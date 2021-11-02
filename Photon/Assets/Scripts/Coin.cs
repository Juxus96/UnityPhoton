using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Action onCollected;

    private void Start()
    {
        LevelManager.onGameWon += () => { gameObject.SetActive(false); };

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onCollected();
            gameObject.SetActive(false);
        }
    }
}
