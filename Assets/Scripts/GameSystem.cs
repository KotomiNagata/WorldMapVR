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
    public bool right = false;   // 右回転
    public bool left = false;    // 左回転

    // 弾
    public bool bullet = false;


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
            bullet = true;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            bullet = false;
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
