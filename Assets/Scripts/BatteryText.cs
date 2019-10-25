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

    GameSystem system;
    BatteryTextParent parent;

    public AnimType animType;
    public Material[] materials; // マテリアル
    Renderer rend;               // カラー
    int cnt = 0;                 // マテリアルを入れるやつ
    bool change = false;         // マテリアルチェンジ
    public int nowNumber;
    int startNumber;

    void Awake()
    {
        system = GetComponent<GameSystem>();
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        parent = FindObjectOfType<BatteryTextParent>();
        rend.material = materials[cnt = 0];
    }

    void Update()
    {
        if (animType == AnimType.MIDDLE)
        {
            startNumber = nowNumber;
            nowNumber = parent.numberMiddle;
            if (nowNumber != startNumber)
            {
                change = true;
            }
            if (change)
            {
                rend.material = materials[cnt = nowNumber];
                change = false;
            }
        }
        if (animType == AnimType.RIGHT)
        {
            startNumber = nowNumber;
            nowNumber = parent.numberRight;
            if (nowNumber != startNumber)
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
            startNumber = nowNumber;
            nowNumber = parent.numberLeft;
            if (nowNumber != startNumber)
            {
                change = true;
            }
            if (change)
            {
                rend.material = materials[cnt = nowNumber];
                change = false;
            }
        }
        /*
        if(system.noon)
        {
            rend.material = materials[cnt = 0];
        }*/
    }
}
