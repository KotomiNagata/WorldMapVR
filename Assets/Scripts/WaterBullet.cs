using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public Rigidbody rbody;
    public float xPosition = 0f;   // xの位置
    public float radius = 2.0f;    // 半径
    public float speed = 1.0f;     // スピード
    public float timer = 2.0f;     // タイマー時間
    public GameObject particle;    // パーティクル
    bool clone = false;            // パーティクル生産用
    bool scaleChange;

    void Start()
    {

    }

    void Update()
    {
        // タイマー
        this.timer -= Time.deltaTime;
        if (this.timer < 0)
        {
            clone = true;
        }

        WaterAnimation();
        Mawaru();

        // パーティクル生産
        if(clone)
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
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

    // 円運動・回転
    void Mawaru()
    {
        // 回転
        transform.Rotate(new Vector3(-114.285f, 0, 0) * Time.deltaTime, Space.World);

        // 円運動
        rbody.MovePosition(
            new Vector3(
                xPosition,
                radius * Mathf.Cos(Time.time * speed),
                radius * Mathf.Sin(Time.time * -speed)
             )
        );
    }

}
