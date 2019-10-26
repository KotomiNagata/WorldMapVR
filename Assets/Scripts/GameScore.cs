using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    GameSystem system;

    public int score = 0;
    public int enemyEnelgy = 0;
    public bool Hissatsuwaza = false;

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
    }

    public void AddPoint(int point)
    {
        score = score + point;
    }

    public void AddEnemyEnelgy(int point)
    {
        if(enemyEnelgy < 10)
        {
            enemyEnelgy = enemyEnelgy + point;
        }
    }

    void Update()
    {
        if (system.decision)
        {
            Hissatsuwaza = true;
            enemyEnelgy = 0;
        }
    }
}
