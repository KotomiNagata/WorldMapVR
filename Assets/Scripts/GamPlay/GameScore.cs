using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    GameSystem system;
    GameRecord record;

    [System.NonSerialized]
    public bool Hissatsuwaza = false;
    [System.NonSerialized]
    public int enemyEnelgy = 0;

    [Header("現在のスコア")]  // 確認用
    public int score = 0;
    int enemyNumber = 0;

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        record = FindObjectOfType<GameRecord>();
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

    public void AddEnemyDieNumber(int point)
    {
        enemyNumber = enemyNumber + point;
    }

    void Update()
    {
        if (system.decision)
        {
            Hissatsuwaza = true;
            enemyEnelgy = 0;
        }
    }

    void SceneChange()
    {
        record.intEnemy = enemyNumber;
        record.intScore = score;
    }
}
