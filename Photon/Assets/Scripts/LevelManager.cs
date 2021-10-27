using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static Action<int> onScoreUpdate;
    private int currentScore;

    private void Start()
    {
        Coin.onCollected += () => { currentScore++; onScoreUpdate(currentScore); } ;
    }
}
