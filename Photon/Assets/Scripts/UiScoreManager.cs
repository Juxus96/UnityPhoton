using System;
using TMPro;
using UnityEngine;

public class UiScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; 

    private void Start()
    {
        LevelManager.onScoreUpdate += UpdateUI;
    }

    private void UpdateUI(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }

    private void Update()
    {
        
    }
}
