using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryText : MonoBehaviour
{
    public enum AnimType
    {
        MIDDLE,
        RIGHT,
        LEFT
    }

    BatteryTextParent parent;

    public AnimType animType;
    public Material[] materials; // マテリアル
    Renderer rend;               // カラー
    int cnt = 0;                 // マテリアルを入れるやつ
    bool change = false;         // マテリアルチェンジ
    int nowNumber;
    int startNumner;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        parent = FindObjectOfType<BatteryTextParent>();
    }

    void Update()
    {
        if (animType == AnimType.MIDDLE)
        {
            startNumner = nowNumber;
            nowNumber = parent.numberMiddle;
            if(nowNumber != startNumner)
            {
                change = true;
            }
            if(change)
            {
                rend.material = materials[cnt = nowNumber];
                change = false;
            }
        }
        if (animType == AnimType.RIGHT)
        {
            startNumner = nowNumber;
            nowNumber = parent.numberRight;
            if (nowNumber != startNumner)
            {
                change = true;
            }
            if (change)
            {
                rend.material = materials[cnt = nowNumber];
                change = false;
            }
        }
        if (animType == AnimType.LEFT)
        {
            startNumner = nowNumber;
            nowNumber = parent.numberLeft;
            if (nowNumber != startNumner)
            {
                change = true;
            }
            if (change)
            {
                rend.material = materials[cnt = nowNumber];
                change = false;
            }
        }
    }
}
