using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        LevelManager.onGameWon += () => { winPanel.SetActive(true); };
    }

    private void Update()
    {
        
    }
}
