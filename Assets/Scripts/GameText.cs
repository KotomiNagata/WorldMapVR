using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameText : MonoBehaviour
{
    public enum AnimType
    {
        G_NUMBER,
        R_NUMBER,
        FINISH
    }
    public AnimType animType;

    // G_NUMBER (ズーム + フェード)
    private Renderer rend;
    private Color color;
    float alpha;
    Vector3 thisSize;
    float appeanTime = 0.6f;
    float appeanSpeed = 0.005f;

    // R_NUMBER
    float timer = 1f;

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
    }

    void Update()
    {
        if(animType == AnimType.G_NUMBER)
        {
            StartCoroutine("Appean");
        }

        if(animType == AnimType.R_NUMBER)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                Destroy(this.gameObject);
            }
        }

        if (animType == AnimType.FINISH)
        {
            // 回転
            transform.Rotate(new Vector3(0, -0.3f, 0));
        }
    }

    private IEnumerator Appean()
    {
        Vector3 scale = this.gameObject.transform.localScale;

        //拡大する
        gameObject.transform.localScale = new Vector3(
            scale.x + appeanSpeed,
            scale.y + appeanSpeed,
            scale.z
        );

        //もし大きさが1.3を超えたら拡大を止める
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
}
