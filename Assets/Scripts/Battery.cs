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
    public float YRot;           // 自分のY_Rotationを取得
    public float speed = 1.0f;   // スピード
    public GameObject bullet;    // 弾のObj
    public GameObject bulletSpecial;// クイズを発生させる弾
    public GameObject textGetManyPoint;
    public GameObject textGood;
    public GameObject textMiss;

    // BODY
    bool bulletCreat = false;    // 弾を生成してもいいか
    bool textGetManyPointCreat = false;

    // マテリアル
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
            // YのRotationを取得→WaterBulletへ教える
            YRot = this.gameObject.transform.rotation.y;

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
            if(system.bullet)
            {
                if(bulletCreat)
                {
                    if(!system.quizStart)
                    {
                        // 普通の弾
                        Instantiate(bullet, transform.position, transform.rotation);
                    }
                    if (system.quizStart)
                    {
                        // クイズ問題発生させる弾
                        Instantiate(bulletSpecial, transform.position, transform.rotation);
                    }
                    bulletCreat = false;
                }
            }
            if(!system.bullet)
            {
                bulletCreat = true;
            }
        }

        if (animType == AnimType.BULLET)
        {
            if(system.bullet && change == false)
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

        if (animType == AnimType.RIGHT)
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

        if (animType == AnimType.LEFT)
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

        if (animType == AnimType.MATER)
        {
            colorLevelStart = colorLevel;
            colorLevel = score.enemyEnelgy;
            if(colorLevel != colorLevelStart)
            {
                change = true;
            }
            if(change)
            {
                rend.material = materials[cnt = colorLevel];
                change = false;
            }
        }

        if (animType == AnimType.TEXT)
        {
            // テキスト生成
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
            else
            {
                textGetManyPointCreat = true;
            }
        }
    }
}
