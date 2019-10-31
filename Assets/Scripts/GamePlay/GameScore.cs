using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    GameSystem system;
    GameRecord record;
    TimeAttack attack;

    [System.NonSerialized]
    public bool Hissatsuwaza = false;
    [System.NonSerialized]
    public int enemyEnelgy = 0;

    [Header("現在のスコア")]  // 確認用
    public int score = 0;
    int enemyNumber = 0;
    bool recordChange = true;

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        record = FindObjectOfType<GameRecord>();
        attack = FindObjectOfType<TimeAttack>();
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

        if(!attack.finishClone && recordChange)
        {
            SceneChange();
        }
    }

    void SceneChange()
    {
        record.intScore = score;
        record.intEnemy = enemyNumber;
        record.AllTrue();
        recordChange = false;
    }
}
