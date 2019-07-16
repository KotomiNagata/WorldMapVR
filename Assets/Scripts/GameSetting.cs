using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    // 操作などの命令はここに。

    public bool advance = false;     // 前進
    public bool retreat = false;     // 後退
    public bool r_rotation = false;  // 右回転
    public bool l_rotation = false;  // 左回転
    public bool LeftOarStop = true;  // Animation_Oarから命令
    public bool RightOarStop = true; // Animation_Oarから命令

    void Start()
    {
        
    }


    void Update()
    {
        // 前進
        if (Input.GetKey(KeyCode.UpArrow))
        {
            advance = true;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            advance = false;
        }

        // 後退(未使用)
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
            r_rotation = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            r_rotation = false;
        }

        // 左回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            l_rotation = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            l_rotation = false;
        }
    }
}
