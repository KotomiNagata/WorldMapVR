using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    GameSystem system;
    GameScore score;

    public enum AnimType
    {
        BODY,   // 回転移動、弾の生成
        BULLET, // マークが光る
        RIGHT,  // マークが光る
        LEFT,   // マークが光る
        MATER,
        TEXT    // テキスト生成
    }

    public AnimType animType;

    [Header("BODY")]
    public float speed = 1.0f;           // スピード
    public GameObject bullet;            // 弾のObj
    public GameObject bulletSpecial;     // クイズを発生させる弾
    bool bulletCreat = false;            // 弾を生成してもいいか

    [Header("TEXT")]
    public GameObject textGetManyPoint;  // 「高得点チャンス！」生成
    public GameObject textStartQuiz;     // 「クイズ発！」生成
    public GameObject textGood;          // 「Good!」生成
    public GameObject textMiss;          // 「Miss...」生成
    public GameObject ButtonAppean;      // 操作についての文字を生成
    bool textGetManyPointCreat = false;
    bool textStartQuizCreat = false;
    bool textGoodCreat = false;
    bool textMissCreat = false;
    bool ButtonAppeanCreat = false;

    [Header("マテリアル")]
    public Material[] materials; // マテリアル
    Renderer rend;               // カラー
    int cnt = 0;                 // マテリアルを入れるやつ
    bool change = false;         // マテリアルチェンジ
    int colorLevelStart = 0;
    int colorLevel = 0;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        score = FindObjectOfType<GameScore>();

        if (animType == AnimType.BULLET ||
            animType == AnimType.RIGHT ||
            animType == AnimType.LEFT ||
            animType == AnimType.MATER)
        {
            rend.material.color = materials[cnt].color;
        }
    }

    void Update()
    {
        if (animType == AnimType.BODY)
        {
            BodyScript();
        }

        if (animType == AnimType.BULLET)
        {
            BulletScript();
        }

        if (animType == AnimType.RIGHT)
        {
            RightScript();
        }

        if (animType == AnimType.LEFT)
        {
            LeftScript();
        }

        if (animType == AnimType.MATER)
        {
            MaterScript();
        }

        if (animType == AnimType.TEXT)
        {
            TextScript();
        }
    }

    void BodyScript()
    {
        // 回転移動
        if (system.right)
        {
            transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime, Space.World);
        }
        if (system.left)
        {
            transform.Rotate(new Vector3(0, -speed, 0) * Time.deltaTime, Space.World);
        }

        // 弾を生成
        if (system.bullet)
        {
            if (bulletCreat)
            {
                if (!system.quizSelect)
                {
                    // 普通の弾
                    Instantiate(bullet, transform.position, transform.rotation);
                }
                if (system.quizSelect)
                {
                    // クイズ問題発生させる弾
                    Instantiate(bulletSpecial, transform.position, transform.rotation);
                }
                bulletCreat = false;
            }
        }
        if (!system.bullet)
        {
            bulletCreat = true;
        }
    }

    void BulletScript()
    {
        if (system.bullet && change == false)
        {
            rend.material = materials[cnt = 1];
            change = true;
        }
        if (!system.bullet && change == true)
        {
            rend.material = materials[cnt = 0];
            change = false;
        }
    }

    void RightScript()
    {
        if (system.right && change == false)
        {
            rend.material = materials[cnt = 1];
            change = true;
        }
        if (!system.right && change == true)
        {
            rend.material = materials[cnt = 0];
            change = false;
        }
    }

    void LeftScript()
    {
        if (system.left && change == false)
        {
            rend.material = materials[cnt = 1];
            change = true;
        }
        if (!system.left && change == true)
        {
            rend.material = materials[cnt = 0];
            change = false;
        }
    }

    void MaterScript()
    {
        colorLevelStart = colorLevel;
        colorLevel = score.enemyEnelgy;
        if (colorLevel != colorLevelStart)
        {
            change = true;
        }
        if (change)
        {
            rend.material = materials[cnt = colorLevel];
            change = false;
        }
    }

    void TextScript()
    {
        // 「高得点チャンス！」
        if (!system.noon)
        {
            if (textGetManyPointCreat)
            {
                GameObject obj = (GameObject)Instantiate(textGetManyPoint,
                                                         this.transform.position,
                                                         this.transform.rotation);
                obj.transform.parent = transform;
                textGetManyPointCreat = false;
            }
        }

        // 「クイズ発生！」
        if(system.selectEnemy)
        {
            if(textStartQuizCreat)
            {
                GameObject obj = (GameObject)Instantiate(textStartQuiz,
                                                         this.transform.position,
                                                         this.transform.rotation);
                obj.transform.parent = transform;
                textStartQuizCreat = false;
            }
        }

        // 操作についての文字
        if(system.quizSelect)
        {
            if(ButtonAppeanCreat)
            {
                GameObject obj = (GameObject)Instantiate(ButtonAppean,
                                                         this.transform.position,
                                                         this.transform.rotation);
                obj.transform.parent = transform;
                ButtonAppeanCreat = false;
            }
        }

        // 「Good!」
        if(system.quizEnd && system.quizGood)
        {
            if(textGoodCreat)
            {
                GameObject obj = (GameObject)Instantiate(textGood,
                                                            this.transform.position,
                                                            this.transform.rotation);
                obj.transform.parent = transform;
                textGoodCreat = false;
            }
        }

        // 「Miss...」
        if(system.quizEnd && system.quizMiss)
        {
            if(textMissCreat)
            {
                GameObject obj = (GameObject)Instantiate(textMiss,
                                                            this.transform.position,
                                                            this.transform.rotation);
                obj.transform.parent = transform;
                textMissCreat = false;
            }
        }

        // 文字生成用のBoolをリセット
        if(!system.quizStart)
        {
            textGetManyPointCreat = true;
            textStartQuizCreat = true;
            textGoodCreat = true;
            textMissCreat = true;
            ButtonAppeanCreat = true;
        }
    }
}
