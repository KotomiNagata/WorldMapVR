using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeObject : MonoBehaviour
{
    public enum FadeType
    {
        FADEIN,
        FADEOUT
    }

    public FadeType fadeType;

    public string nextSceneName;
    private Renderer rend;
    private Color color;
    float C;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (fadeType == FadeType.FADEIN)
        {
            rend.material.color = new Color(1f, 1f, 1f, 0.0f); // 初期化
            C = 0;
        }

        if(fadeType == FadeType.FADEOUT)
        {
            C = 1;
        }
    }

    void Update()
    {
        if (fadeType == FadeType.FADEIN)
        {
            FadeIn();
        }

        if (fadeType == FadeType.FADEOUT)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        C = C + Time.deltaTime * 1f;
        rend.material.color = new Color(1f, 1f, 1f, C);

        // 浮動小数点数の時は後ろにfをつける
        if (C >= 1.0f)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void FadeOut()
    {
        C = C - Time.deltaTime * 1f;
        rend.material.color = new Color(1f, 1f, 1f, C);

        // 完全に透明になったら削除
        if (C < 0)
        {
            Destroy(gameObject);
        }
    }
}
