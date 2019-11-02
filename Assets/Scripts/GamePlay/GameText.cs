using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameText : MonoBehaviour
{
    // タイムリミットの数字のアニメーション
    // 終わった時の「Finish」のアニメーション
    public enum AnimType
    {
        G_NUMBER,
        R_NUMBER,
        FINISH,
        BATTERY_TEXT,
        BUTTON_APPEAN
    }
    public AnimType animType;
    GameSystem system;
    GameScore score;

    // G_NUMBER
    private Renderer rend;
    private Color color;
    float alpha;
    Vector3 thisSize;
    float appeanTime = 0.6f;
    float appeanSpeed = 0.005f;

    // R_NUMBER
    float timer = 1f;

    [Header("FINISH")]
    public GameObject fadeObj;
    public string sceneName;
    FadeObject fade;
    float finishTime = 3f;
    bool creatObj = true;

    [Header("BATTERY_TEXT")]
    public bool good = false;
    public bool miss = false;
    bool kakudai = true;
    bool syukusyou = false;
    bool end = false;

    void Start()
    {
        if (animType == AnimType.G_NUMBER)
        {
            rend = GetComponent<Renderer>();
            rend.material.color = new Color(1f, 1f, 1f, 1f); // 初期化
            alpha = 1;

            thisSize = gameObject.transform.localScale;
            Vector3 scale = this.gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(0, 0, scale.z);
        }

        if(animType == AnimType.BATTERY_TEXT)
        {
            system = FindObjectOfType<GameSystem>();
            score = FindObjectOfType<GameScore>();
            thisSize = gameObject.transform.localScale;
            Vector3 scale = this.gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(0, 0, scale.z);
        }

        if(animType == AnimType.BUTTON_APPEAN)
        {
            system = FindObjectOfType<GameSystem>();
        }
    }

    void Update()
    {
        if (animType == AnimType.G_NUMBER)
        {
            StartCoroutine("Appean_G_NUMBER");
        }

        if (animType == AnimType.R_NUMBER)
        {
            R_NumberScript();
        }

        if (animType == AnimType.FINISH)
        {
            FinishScript();
        }

        if (animType == AnimType.BATTERY_TEXT)
        {
            StartCoroutine("Appean_BATTERY_TEXT");
        }

        if(animType == AnimType.BUTTON_APPEAN)
        {
            ButtonAppeanScript();
        }
    }

    void R_NumberScript()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            Destroy(this.gameObject);
        }
    }

    void FinishScript()
    {
        // 回転
        transform.Rotate(new Vector3(0, -0.3f, 0));

        finishTime -= Time.deltaTime;

        if(finishTime <= 0 && creatObj)
        {
            Instantiate(fadeObj);
            fade = FindObjectOfType<FadeObject>();
            fade.nextSceneName = sceneName;
            creatObj = false;
        }
    }

    private IEnumerator Appean_G_NUMBER()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        //拡大する
        gameObject.transform.localScale = new Vector3(
            scale.x + appeanSpeed,
            scale.y + appeanSpeed,
            scale.z
        );

        //拡大を止める
        if (scale.x > thisSize.x)
        {
            gameObject.transform.localScale = new Vector3(
            scale.x,
            scale.y,
            scale.z
        );
        }

        yield return new WaitForSeconds(appeanTime);

        alpha = alpha - Time.deltaTime * 3f;
        rend.material.color = new Color(1f, 1f, 1f, alpha);

        //もし完全に消えたらオブジェクトを消す
        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Appean_BATTERY_TEXT()
    {
        if(!end)
        {
            Vector3 scale = this.gameObject.transform.localScale;

            if (scale.x > thisSize.x + 0.01 && kakudai)
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

        yield return new WaitForSeconds(1f);

        if(good)
        {
            score.AddPoint(1000);
            system.quizStart = false;
        }
        if(miss)
        {
            score.AddPoint(100);
            system.quizStart = false;
        }
        Destroy(this.gameObject);
    }

    void ButtonAppeanScript()
    {
        if(system.decision)
        {
            Destroy(this.gameObject);
        }
    }

}
