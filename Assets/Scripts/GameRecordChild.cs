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
        LANKING_NUMBER,
        LANKING_SCORE
    }
    public Type type;
    TextMesh text;
    GameRecord parent;

    public GameObject thisObject;
    string myNumberText;
    int myNumber;

    // アニメ
    int textAnime01;
    string textAnime02;
    float time = 1f;
    bool stop = false;

    // ランキング
    int No1;
    int No2;
    int No3;
    int No4;
    int No5;
    private int n;

    void Start()
    {
        parent = FindObjectOfType<GameRecord>();
        text = thisObject.GetComponent<TextMesh>();
        if(type == Type.SCORE)
        {
            myNumber = parent.intScore;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.ENEMY)
        {
            myNumber = (int)parent.intEnemy;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.BONUS)
        {
            myNumber = parent.intBonus;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.TOTAL_SCORE)
        {
            myNumber = parent.intTotalScore;
            myNumberText = Convert.ToString(myNumber);
        }
        if (type == Type.LANKING_SCORE)
        {
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
            //text.text = myNumberText;
            Debug.Log(parent.nowLanking[0]);
        }
    }
    /*
    void Update()
    {
        if(type != Type.LANKING_NUMBER)
        {
            this.time -= Time.deltaTime;
            if (time <= 0)
            {
                stop = true;
            }

            if (!stop)
            {
                TextAnimation();
            }

            if (stop)
            {
                if (type == Type.SCORE ||
                   type == Type.ENEMY ||
                   type == Type.BONUS)
                {
                    text.text = myNumberText;
                }
                if (type == Type.LANKING_SCORE)
                {
                    string tNo1 = Convert.ToString(No1);
                    string tNo2 = Convert.ToString(No2);
                    string tNo3 = Convert.ToString(No3);
                    string tNo4 = Convert.ToString(No4);
                    string tNo5 = Convert.ToString(No5);
                }
            }
            //改行は/n
        }
    }*/

    void TextAnimation()
    {
        textAnime01 = UnityEngine.Random.Range(0000, 9999);
        textAnime02 = Convert.ToString(textAnime01);
        text.text = textAnime02;
    }
}
