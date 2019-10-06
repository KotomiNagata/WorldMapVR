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
        if(Input.GetKey("joystick button 17"))
        {
            bullet = true;
        }
        if(Input.GetKeyUp("joystick button 17"))
        {
            bullet = false;
        }

        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");

        // 右回転
        if (lsh == 1f && lsv == 0f)
        {
            right = true;
        }
        else
        {
            right = false;
        }

        // 左回転
        if (lsh == -1 && lsv == 0)
        {
            left = true;
        }
        else
        {
            left = false;
        }

    }
}
