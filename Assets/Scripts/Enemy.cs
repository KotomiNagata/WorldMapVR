using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum AnimType
    {
        APPEAN,
        STAND,
        DAMAGE,
        HIDE
    }
    public AnimType animType;
    public GameObject nextAnime; // 次の動きのObjを入れる
    public float time;
    public float speed;
    Vector3 startPos;
    // アニメを終わらせてから次へ移行
    // STANDだけアニメを数回決めてから移行
    // 当たり判定はWaterBulletと連携
    // DAMAGEの次の花のエフェクトは、花が作る


    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        if (animType == AnimType.APPEAN)
        {
            if(this.transform.position.y < startPos.y + 0.003)
            {
                this.gameObject.transform.Translate(0, speed, 0);
            }

            // タイマー
            this.time -= Time.deltaTime;
            if (this.time < 0)
            {
                Instantiate(nextAnime, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }

        if (animType == AnimType.STAND)
        {
            // タイマー
            this.time -= Time.deltaTime;
            if (this.time < 0)
            {
                Instantiate(nextAnime, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }

        if (animType == AnimType.HIDE)
        {
            if (startPos.y - 0.05 < this.transform.position.y)
            {
                this.gameObject.transform.Translate(0, -speed, 0);
            }

            // タイマー
            this.time -= Time.deltaTime;
            if (this.time < 0)
            {
                //Instantiate(nextAnime, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

}
