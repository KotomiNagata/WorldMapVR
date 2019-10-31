using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameRecordChild : MonoBehaviour
{
    public enum Type
    {
        SCORE,
        ENEMY,
        BONUS,
        TOTAL_SCORE,
        LANKING_SCORE,
        LANKING_NUMBER
    }
    public Type type;
    TextMesh text;
    GameRecord parent;

    [Header("LANKING_NUMBER以外アタッチ")]
    public GameObject thisObject;
    string myNumberText;
    int myNumber;

    // アニメ
    int textAnime01;
    string textAnime02;
    float time = 0.5f;
    bool stop = false;

    // ランキング
    int No1;
    int No2;
    int No3;
    int No4;
    int No5;
    private int n;

    // LANKING_NUMBER
    Vector3 thisSize;
    bool kakudai = true;
    bool syukusyou = false;
    bool end = false;
    float appeanSpeed = 0.05f;

    void Start()
    {
        if(type == Type.SCORE)
        {
            parent = FindObjectOfType<GameRecord>();
            text = thisObject.GetComponent<TextMesh>();
            myNumber = parent.intScore;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.ENEMY)
        {
            parent = FindObjectOfType<GameRecord>();
            text = thisObject.GetComponent<TextMesh>();
            myNumber = (int)parent.intEnemy;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.BONUS)
        {
            parent = FindObjectOfType<GameRecord>();
            text = thisObject.GetComponent<TextMesh>();
            myNumber = parent.intBonus;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.TOTAL_SCORE)
        {
            parent = FindObjectOfType<GameRecord>();
            text = thisObject.GetComponent<TextMesh>();
            myNumber = parent.intTotalScore;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.LANKING_SCORE)
        {
            parent = FindObjectOfType<GameRecord>();
            text = thisObject.GetComponent<TextMesh>();
            No1 = parent.nowLanking[0];
            No2 = parent.nowLanking[1];
            No3 = parent.nowLanking[2];
            No4 = parent.nowLanking[3];
            No5 = parent.nowLanking[4];
            myNumberText =
                        No1 + "\n" +
                        No2 + "\n" +
                        No3 + "\n" +
                        No4 + "\n" +
                        No5;
        }
        if(type == Type.LANKING_NUMBER)
        {
            thisSize = gameObject.transform.localScale;
        }
    }

    void Update()
    {
        if (type == Type.SCORE ||
                type == Type.ENEMY ||
                type == Type.BONUS ||
                type == Type.TOTAL_SCORE)
        {
            NoLanking();
        }

        if (type == Type.LANKING_SCORE)
        {
            Lanking();
        }

        if(type == Type.LANKING_NUMBER)
        {
            if(!end)
            {
                AnimationLankingNumber();
            }
        }
    }

    void Lanking()
    {
        text.text = myNumberText;

        string tNo1 = Convert.ToString(No1);
        string tNo2 = Convert.ToString(No2);
        string tNo3 = Convert.ToString(No3);
        string tNo4 = Convert.ToString(No4);
        string tNo5 = Convert.ToString(No5);

        text.text = tNo1 + "\n" + tNo2 + "\n" + tNo3 + "\n" + tNo4 + "\n" + tNo5;
    }

    void NoLanking()
    {
        if (stop)
        {
            text.text = myNumberText;
        }

        this.time -= Time.deltaTime;
        if (time <= 0)
        {
            stop = true;
        }

        if (!stop)
        {
            TextAnimation();
        }
    }

    void TextAnimation()
    {
        textAnime01 = UnityEngine.Random.Range(0000, 9999);
        textAnime02 = Convert.ToString(textAnime01);
        text.text = textAnime02;
    }

    void AnimationLankingNumber()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        if (scale.x > thisSize.x + 0.1 && kakudai)
        {
            kakudai = false;
            syukusyou = true;
        }

        if (scale.x < thisSize.x && syukusyou)
        {
            syukusyou = false;
            end = true;
        }

        //拡大する
        if (kakudai)
        {
            gameObject.transform.localScale = new Vector3(
        scale.x + appeanSpeed,
        scale.y + appeanSpeed,
        scale.z
        );
        }

        // 縮小する
        if (syukusyou)
        {
            gameObject.transform.localScale = new Vector3(
            scale.x - appeanSpeed,
            scale.y - appeanSpeed,
            scale.z);
        }
    }
}
