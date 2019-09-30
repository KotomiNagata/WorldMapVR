using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    GameSystem system;

    public enum AnimType
    {
        BODY,   // 回転移動、弾の生成
        BULLET, // マークが光る
        RIGHT,  // マークが光る
        LEFT    // マークが光る
    }
    public AnimType animType;
    public float speed = 1.0f;   // スピード
    public GameObject bullet;    // 弾のObj
    bool bulletCreat = false;    // 弾を生成してもいいか
    public Material[] materials; // マテリアル
    Renderer rend;               // カラー
    int cnt = 0;                 // マテリアルを入れるやつ
    bool change = false;         // マテリアルチェンジ

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        system = FindObjectOfType<GameSystem>();

        if (animType == AnimType.BULLET ||
            animType == AnimType.RIGHT ||
            animType == AnimType.LEFT)
        {
            rend.material.color = materials[cnt].color;
        }
    }

    void Update()
    {
        if (animType == AnimType.BODY)
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
            if(system.bullet)
            {
                if(bulletCreat)
                {

                    Instantiate(bullet, transform.position, transform.rotation);
                    bulletCreat = false;
                }
            }
            if(!system.bullet)
            {
                bulletCreat = true;
            }
        }

        if(animType == AnimType.BULLET)
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
    }
}
