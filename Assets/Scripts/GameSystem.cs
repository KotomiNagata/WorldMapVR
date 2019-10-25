using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 操作についてのコード
    // クイズ問題発生のコード

    TimeAttack attack;
    GameScore score;

    // 移動の切り替え
    public bool right = false;   // 右回転
    public bool left = false;    // 左回転

    // 弾
    public bool bullet = false;

    // 文字入れ替え
    public bool rightText = false;
    public bool leftText = false;

    // 操作制限
    bool move = false;
    bool bulletEnd = false;

    // クイズ問題
    public bool noon = true;          // 昼・夜切り替え
    public bool quizStart = false;    // クイズスタート合図
    public bool selectEnemy = false;  // クイズスタート後エネミーを選んだ合図
    public string enemyName = "None"; // WaterBulletから代入

    void Start()
    {
        attack = FindObjectOfType<TimeAttack>();
        score = FindObjectOfType<GameScore>();
    }

    void Update()
    {
        if(!attack.startClone)
        {
            move = true;

            if(!attack.finishClone)
            {
                move = false;
                bulletEnd = true;
            }
        }

        // 弾を打つ
        if (Input.GetKey("joystick button 17") && !bulletEnd)
        {
            bullet = true;
        }
        if(Input.GetKeyUp("joystick button 17") && !bulletEnd)
        {
            bullet = false;
        }

        // 文字入れ替え
        if (Input.GetKey("joystick button 13")) // 左
        {
            leftText = true;
        }
        if (Input.GetKeyUp("joystick button 13"))
        {
            leftText = false;
        }
        if (Input.GetKey("joystick button 14")) // 右
        {
            rightText = true;
        }
        if (Input.GetKeyUp("joystick button 14"))
        {
            rightText = false;
        }

        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        // 右回転
        if (lsh == 1f && lsv == 0f && move)
        {
            right = true;
        }
        else
        {
            right = false;
        }

        // 左回転
        if (lsh == -1 && lsv == 0 && move)
        {
            left = true;
        }
        else
        {
            left = false;
        }

        if(score.enemyEnelgy == 10)
        {
            QuizGame();
            quizStart = true;
        }

        if(!quizStart)
        {
            selectEnemy = false;
        }

    }

    void QuizGame()
    {
        if(enemyName != "None")
        {
            noon = false;
        }
    }

}
