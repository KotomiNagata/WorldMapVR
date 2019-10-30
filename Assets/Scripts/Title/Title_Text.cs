using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Text : MonoBehaviour
{
    Vector3 thisSize;
    bool kakudai = true;
    bool syukusyou = false;
    float appeanSpeed = 0.001f;

    void Start()
    {
        thisSize = gameObject.transform.localScale;
    }

    void Update()
    {
        PlayStart();
    }

    void PlayStart()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        if (scale.x > thisSize.x + 0.01 && kakudai)
        {
            kakudai = false;
            syukusyou = true;
        }

        if (scale.x < thisSize.x - 0.01 && syukusyou)
        {
            syukusyou = false;
            kakudai = true;
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
