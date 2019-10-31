using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 操作についてのコード
    // クイズ問題発生のコード

    TimeAttack attack;
    GameScore score;

    // 移動
    [System.NonSerialized]
    public bool right = false;   // 右回転
    [System.NonSerialized]
    public bool left = false;    // 左回転

    // 弾
    [System.NonSerialized]
    public bool bullet = false;

    // 文字入れ替え
    [System.NonSerialized]
    public bool rightText = false;
    [System.NonSerialized]
    public bool leftText = false;

    // 操作制限
    bool move = false;
    bool bulletEnd = false;

    [Header("クイズ問題の合図")]
    public bool noon = true;             // 昼・夜切り替え
    public bool quizStart = false;       // これからクイズをスタート合図
                                         // GameTextがfalse指示
    public bool selectEnemy = false;     // クイズスタート後エネミーを選び、クイズ終了までTrue
                                         // WaterBulletがtrueに変更
                                         // Batteryがfalseに変更
    public bool quizSelect = false;      // エネミーに当たり、選択肢が表示される合図
    public bool decision = false;        // 答えを決めてから、敵に当たる・外れるまでの合図
                                         // WaterBulletのQuizBulletからfalse指示
    public bool quizGood = false;        // 正解した合図
                                         // BatteryTextのMIDDLEから指示
    public bool quizMiss = false;        // 誤った合図
                                         // BatteryTextのMIDDLEから指示
                                         // WaterBulletのQuizBulletから指示
    public bool quizEnd = false;         // QuizBulletが消えてクイズ終了

    [System.NonSerialized]
    public string enemyName = "None";    // WaterBulletから代入

    void Start()
    {
        attack = FindObjectOfType<TimeAttack>();
        score = FindObjectOfType<GameScore>();
    }

    void Update()
    {
        // 操作について
        PlayingButtonScript();

        // タイムリミットに合わせて動きを制御
        if(!attack.startClone)
        {
            move = true;

            if(!attack.finishClone)
            {
                move = false;
                bulletEnd = true;
            }
        }

        // ゲージが満タンになった時にクイズ発生
        if(score.enemyEnelgy == 10)
        {
            QuizGame();
            quizStart = true;
        }

        if (!quizStart)
        {
            noon = true;
            quizEnd = false;
            quizGood = false;
            quizMiss = false;
            quizSelect = false;
            selectEnemy = false;
            enemyName = "None";
        }
    }

    void QuizGame()
    {
        noon = false;

        // エネミーに当たったので、選択肢を表示
        if(selectEnemy)
        {
            quizSelect = true;
        }
        /*
        // 決定ボタンを押したので、選択肢は消滅
        if(decision)
        {
            quizSelect = false;
        }*/
    }

    void PlayingButtonScript()
    {
        // 弾を打つ
        if(quizSelect)
        {
            QuizBulletCreatScript();
        }
        else{
            BulletCreatScript();
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
    }

    void BulletCreatScript()
    {
        if (Input.GetKey("joystick button 17") && !bulletEnd)
        {
            bullet = true;
        }
        if (Input.GetKeyUp("joystick button 17") && !bulletEnd
           || GameObject.FindGameObjectWithTag("GameText"))
        {
            bullet = false;
        }
    }

    void QuizBulletCreatScript()
    {
        if (Input.GetKey("joystick button 17") && !bulletEnd && !decision)
        {
            bullet = true;
            decision = true;
        }
    }
}
