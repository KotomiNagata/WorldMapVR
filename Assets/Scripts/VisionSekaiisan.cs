﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSekaiisan : MonoBehaviour
{
    LotusFlower lotus;
    public GameObject colorHaving; // カラーを持っているObj
    float A = 0;                   // 透明カラー(a)の数値
    bool size = true;              // 拡大用

    void Start()
    {
        lotus = FindObjectOfType<LotusFlower>();
    }

    void Update()
    {
        if (size)
        {
            Expansion();
        }

        // 回転
        transform.Rotate(new Vector3(0, 1f, 0));

        Color color = colorHaving.gameObject.GetComponent<Renderer>().material.color;
        color.a = A;
        if (lotus.dis < 3)
        {
            A = 1 - lotus.dis / 3;
        }
        if (lotus.dis > 3)
        {
            Destroy(this.gameObject);
        }
        colorHaving.gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Expansion()
    {
        Vector3 scale = this.gameObject.transform.localScale;
        //拡大する
        gameObject.transform.localScale = new Vector3(
            scale.x + 0.02f,
            scale.y + 0.02f,
            scale.z + 0.02f
        );

        //もし大きさが1.3を超えたら拡大を止める
        if (scale.x > 3)
        {
            size = false;
        }
    }
}
