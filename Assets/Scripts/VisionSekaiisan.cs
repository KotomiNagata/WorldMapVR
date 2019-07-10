using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSekaiisan : MonoBehaviour
{
    Lotus lotus;
    public GameObject colorHaving; // カラーを持っているObj
    float A = 0;                   // 透明カラー(a)の数値

    void Start()
    {
        lotus = FindObjectOfType<Lotus>();
    }

    void Update()
    {
         // 回転
        transform.Rotate(new Vector3(0, 1f, 0));

        Color color = colorHaving.gameObject.GetComponent<Renderer>().material.color;
        color.a = A;
        if (lotus.dis < 3)
        {
            A = 1 - lotus.dis / 3;
        }
        if (lotus.dis > 3)
        {
            Destroy(this.gameObject);
        }
        colorHaving.gameObject.GetComponent<Renderer>().material.color = color;
    }
}
