using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Text : MonoBehaviour
{
    public enum Type
    {
        PARENT_OBJECT,
        TEXT
    }
    public Type type;

    [Header("PARENT_OBJECT")]
    public GameObject fadeObj;
    public string sceneName;
    FadeObject fade;

    // TEXTのアニメーション
    Vector3 thisSize;
    bool kakudai = true;
    bool syukusyou = false;
    float appeanSpeed = 0.001f;

    void Start()
    {
        if(type == Type.TEXT)
        {
            thisSize = gameObject.transform.localScale;
        }
    }

    void Update()
    {
        if (type == Type.TEXT)
        {
            ReturnTitle();
        }

        if (type == Type.PARENT_OBJECT &&
            Input.GetKey("joystick button 17"))
        {
            PushButton();
        }
    }

    void PushButton()
    {
        Instantiate(fadeObj);
        fade = FindObjectOfType<FadeObject>();
        fade.nextSceneName = sceneName;
        Destroy(this.gameObject);
    }

    void ReturnTitle()
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
