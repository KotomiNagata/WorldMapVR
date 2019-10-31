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
    BatteryTextParent parentScript;
    GameObject parentObj;

    public AnimType animType;
    public Material[] materials; // マテリアル
    Renderer rend;               // カラー
    int cnt = 0;                 // マテリアルを入れるやつ
    bool change = false;         // マテリアルチェンジ
    //[System.NonSerialized]
    public int nowNumber;
    int startNumber;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        parentObj = this.transform.root.gameObject;
        parentScript = parentObj.GetComponent<BatteryTextParent>();
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

        if(!system.quizStart)
        {
            rend.material = materials[cnt = 0];
            nowNumber = 0;
        }
    }

    void MiddleScript()
    {
        startNumber = nowNumber;
        nowNumber = parentScript.numberMiddle;
        if (nowNumber != startNumber)
        {
            change = true;
        }
        if (change)
        {
            rend.material = materials[cnt = nowNumber];
            change = false;
        }

        if (system.quizSelect && !system.decision && !system.quizEnd)
        {
            if(parentScript.answer == nowNumber)
            {
                system.quizGood = true;
                system.quizMiss = false;
            }
            if (parentScript.answer != nowNumber)
            {
                system.quizGood = false;
                system.quizMiss = true;
            }
        }
    }

    void RightScript()
    {
        startNumber = nowNumber;
        nowNumber = parentScript.numberRight;
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
        nowNumber = parentScript.numberLeft;
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
