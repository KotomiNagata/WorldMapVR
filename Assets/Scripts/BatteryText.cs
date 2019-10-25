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
            MiddleScript();
        }

        if (animType == AnimType.RIGHT)
        {
            RightScript();
        }

        if (animType == AnimType.LEFT)
        {
            LeftScript();
        }
        /*
        if(system.noon)
        {
            rend.material = materials[cnt = 0];
        }*/
    }

    void MiddleScript()
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

        if (system.quizSelect)
        {
            if(parent.answer == nowNumber)
            {
                system.quizGood = true;
                system.quizMiss = false;
            }
            if (parent.answer != nowNumber)
            {
                system.quizGood = false;
                system.quizMiss = true;
            }
        }
    }

    void RightScript()
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

        if(system.decision)
        {
            rend.material = materials[cnt = 0];
        }
    }

    void LeftScript()
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

        if (system.decision)
        {
            rend.material = materials[cnt = 0];
        }
    }
}
