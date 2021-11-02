using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    public static Action obstacleHit;

    private void Start()
    {
        LevelManager.onGameWon += () => { gameObject.SetActive(false); };
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);    
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            obstacleHit();
        }
    }
}
