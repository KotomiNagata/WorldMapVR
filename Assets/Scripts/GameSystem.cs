using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 操作についてのスクリプト


    /*
     * このScriptを取得しているScript
     * ・WorldMap
     */

    // 昼・夜の切り替え
    public bool noon = true;

    // 移動の切り替え
    public bool advance = false; // 前進
    public bool retreat = false; // 後退
    public bool right = false;   // 右回転
    public bool left = false;    // 左回転

    // 弾
    public GameObject bullet;
    bool bulletOK = true;


    void Start()
    {

    }

    void Update()
    {
        // 昼モード・夜モード切り替え
        if (Input.GetKeyUp(KeyCode.Q))
        {
            noon = !noon;
        }

        // 弾を打つ
        if(Input.GetKey(KeyCode.A))
        {
            if(bulletOK)
            {
                Instantiate(bullet);
                bulletOK = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            bulletOK = true;
        }

        // 前進
        if (Input.GetKey(KeyCode.UpArrow))
        {
            advance = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            advance = false;
        }

        // 後退
        if (Input.GetKey(KeyCode.DownArrow))
        {
            retreat = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            retreat = false;
        }

        // 右回転
        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }

        // 左回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
        }

    }
}
