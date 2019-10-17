using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public int score = 0;
    public int enemyEnelgy = 0;
    public bool Hissatsuwaza = false;

    void Start()
    {
        
    }

    public void AddPoint(int point)
    {
        score = score + point;
    }

    public void AddEnemyEnelgy(int point)
    {
        enemyEnelgy = enemyEnelgy + point;

        if(enemyEnelgy == 11)
        {
            Hissatsuwaza = true;
            enemyEnelgy = 0;
        }
    }

    void Update()
    {
        
    }
}
