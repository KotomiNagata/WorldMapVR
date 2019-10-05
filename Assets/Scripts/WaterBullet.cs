using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{

    public enum AnimType
    {
        MOVE,
        ATTACK,
    }

    Battery battery;
    public AnimType animType;
    public float speed = 1.0f;     // スピード
    public float timer = 2.0f;     // タイマー時間
    public GameObject particle;    // パーティクル
    bool clone = false;            // パーティクル生産用
    bool scaleChange;

    void Start()
    {
        if(animType == AnimType.MOVE)
        {
            battery = FindObjectOfType<Battery>();
            Vector3 rot = this.gameObject.transform.localEulerAngles;
            rot.y = battery.gameObject.transform.localEulerAngles.y;
        }
    }

    void Update()
    {
        if (animType == AnimType.MOVE)
        {
            Mawaru();

            // タイマー
            this.timer -= Time.deltaTime;
            if (this.timer < 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (animType == AnimType.ATTACK)
        {
            WaterAnimation();

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
                Destroy(this.gameObject);
            }

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

    // 回転
    void Mawaru()
    {
        // Space.WorldではなくSpace.SelfするとYも回転できるようになる
        // ※下のコードはXでの回転
        transform.Rotate(new Vector3(-speed, 0, 0) * Time.deltaTime, Space.Self);
    }

}
