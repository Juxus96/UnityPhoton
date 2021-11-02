using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action<int> onScoreUpdate;
    public static Action onGameWon;
    public static Action onResetGame;
    
    [SerializeField] private int coinGoal;
    private int currentScore;
    public int CurrentScore 
    { 
        private set 
        { 
            currentScore = Mathf.Max(0, value); 
            onScoreUpdate(currentScore);
            if (currentScore >= coinGoal)
                GameWon();
        } 
        get { return currentScore; } 
    }

    private void Start()
    {
        Coin.onCollected += () => { CurrentScore++; };
        Obstacle.obstacleHit += () => { CurrentScore -= 5; };
    }

    private void GameWon()
    {
        onGameWon();
        Time.timeScale = 0;
    }

    public void Restart()
    {
        onResetGame();
        Time.timeScale = 1;
    }
}
