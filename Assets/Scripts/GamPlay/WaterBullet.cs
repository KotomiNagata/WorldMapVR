using System.Collections;
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

    [Header("ALL")]
    public float timer = 2.0f;       // タイマー時間

    // MOVE
    float speed = 120f;              // スピード

    [Header("ATTACK用(QUIZも含む)")]
    public GameObject particle;      // パーティクル
    public GameObject lotus;         // 花
    public GameObject musicEnemyDie; // エネミーを倒した時の効果音
    GameObject lotusParent;          // 花をまとめる場所
    bool clone = false;              // パーティクル生産用
    bool scaleChange;

    void Start()
    {
        if(animType == AnimType.MOVE)
        {
            battery = FindObjectOfType<Battery>();
            Vector3 rot = this.gameObject.transform.localEulerAngles;
            rot.y = battery.gameObject.transform.localEulerAngles.y;
        }

        if(animType == AnimType.ATTACK || animType == AnimType.ATTACK_QUIZ)
        {
            system = FindObjectOfType<GameSystem>();
            lotusParent = GameObject.FindGameObjectWithTag("LotusParent");
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
            AttackScript();
        }

        if (animType == AnimType.ATTACK_QUIZ)
        {
            AttackQuizScript();
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

    void AttackScript()
    {
        // タイマー
        this.timer -= Time.deltaTime;
        if (this.timer < 0)
        {
            clone = true;
        }

        // 夜モードになった瞬間のみ消える
        if(GameObject.FindGameObjectWithTag("GameText"))
        {
            clone = true;
        }

        // パーティクル生産
        if (clone)
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void AttackQuizScript()
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (animType == AnimType.ATTACK_QUIZ)
            {
                Destroy(other.gameObject);
                Instantiate(musicEnemyDie);
                Instantiate(particle, this.transform.position, Quaternion.identity);
                var parent = lotusParent.transform;
                Instantiate(lotus, other.transform.position, other.transform.rotation, parent);

                system.decision = false;
                system.quizEnd = true;

                Destroy(this.gameObject);
            }

            if (animType == AnimType.ATTACK)
            {
                if (!system.quizStart)
                {
                    Destroy(other.gameObject);
                    Instantiate(musicEnemyDie);
                    var parent = lotusParent.transform;
                    Instantiate(lotus, other.transform.position, other.transform.rotation, parent);
                }
                else
                {
                    system.enemyName = other.name;
                    system.selectEnemy = true;
                }
                Instantiate(particle, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

}
