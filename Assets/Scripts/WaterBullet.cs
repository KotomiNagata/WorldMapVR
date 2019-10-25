﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{

    public enum AnimType
    {
        MOVE,
        ATTACK,
        ATTACK_QUIZ
    }

    GameSystem system;
    Battery battery;
    public AnimType animType;

    public float speed = 1.0f;       // スピード
    public float timer = 2.0f;       // タイマー時間
    public GameObject particle;      // パーティクル
    public GameObject lotus;         // 花
    GameObject lotusParent;          // 花をまとめる場所
    bool clone = false;              // パーティクル生産用
    bool scaleChange;
    public GameObject musicEnemyDie; // エネミーを倒した時の効果音
    string quizEnemyName;

    void Start()
    {
        if(animType == AnimType.MOVE)
        {
            battery = FindObjectOfType<Battery>();
            Vector3 rot = this.gameObject.transform.localEulerAngles;
            rot.y = battery.gameObject.transform.localEulerAngles.y;
        }
        if(animType == AnimType.ATTACK)
        {
            lotusParent = GameObject.FindGameObjectWithTag("LotusParent");
        }
        if (animType == AnimType.ATTACK_QUIZ)
        {
            system = FindObjectOfType<GameSystem>();
        }
    }

    void Update()
    {
        if (animType == AnimType.MOVE)
        {
            MoveScript();
        }

        if(animType == AnimType.ATTACK)
        {
            WaterAnimation();
        }

        if (animType == AnimType.ATTACK ||
           animType == AnimType.ATTACK_QUIZ)
        {
            AttackAndQuiz_Script();
        }
    }

    // 振動アニメーション
    void WaterAnimation()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        if (scale.x < 5f)
        {
            scaleChange = true;
        }
        if (5.5f < scale.x)
        {
            scaleChange = false;
        }
        if (scaleChange)
        {
            gameObject.transform.localScale = new Vector3(
            scale.x + 0.15f,
            scale.y,
            scale.z - 0.15f
        );
        }
        else if (!scaleChange)
        {
            gameObject.transform.localScale = new Vector3(
            scale.x - 0.15f,
            scale.y,
            scale.z + 0.15f
        );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (animType == AnimType.ATTACK_QUIZ)
            {
                system.decision = false;
                system.quizEnd = true;
                Instantiate(particle, this.transform.position, Quaternion.identity);
                //Instantiate(musicEnemyDie);
                Destroy(this.gameObject);
            }

            if(animType == AnimType.ATTACK)
            {
                if(!system.quizStart)
                {
                    Destroy(other.gameObject);
                    Instantiate(musicEnemyDie);
                    var parent = lotusParent.transform;
                    Instantiate(lotus, other.transform.position, other.transform.rotation, parent);
                }else
                {
                    system.enemyName = other.name;
                    system.selectEnemy = true;
                }
                Instantiate(particle, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    void MoveScript()
    {
        // Space.WorldではなくSpace.SelfするとYも回転できるようになる
        // ※下のコードはXでの回転
        transform.Rotate(new Vector3(-speed, 0, 0) * Time.deltaTime, Space.Self);

        // タイマー
        this.timer -= Time.deltaTime;
        if (this.timer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void AttackAndQuiz_Script()
    {
        // タイマー
        this.timer -= Time.deltaTime;
        if (this.timer < 0)
        {
            clone = true;
        }

        // パーティクル生産
        if (clone)
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            system.decision = false;
            system.quizGood = false;
            system.quizMiss = true;
            system.quizEnd = true;
            Destroy(this.gameObject);
        }
    }
}
