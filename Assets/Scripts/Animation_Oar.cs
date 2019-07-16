using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Oar : MonoBehaviour
{
    GameSetting gameSetting;

    public enum AnimType
    {
        LEFT,
        RIGHT
    }
    public AnimType animType;
    public GameObject OtherOar;
    float speed;            // 移動スピード
    float target_rotateZ;   // 指定された角度
    bool up = true;         // 漕ぐ方向

    void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
        speed = 0f;
    }

    void Update()
    {
        if(animType == AnimType.LEFT)
        {
            RunLeft();
        }
        if (animType == AnimType.RIGHT)
        {
            RunRight();
        }

    }

    void RunLeft()
    {
        Vector3 tran = this.gameObject.transform.localEulerAngles;
        var target = Quaternion.Euler(new Vector3(tran.x, tran.y, target_rotateZ));
        var now_rot = transform.rotation;

        // Angle → ２つの角度の間の数値
        if (Quaternion.Angle(now_rot, target) < 20 && !up)
        {
            if (!gameSetting.advance
                || !gameSetting.r_rotation)
            {
                speed = 0f;
                if(!gameSetting.r_rotation)
                {
                    gameSetting.LeftOarStop = true;
                }
            }
        }
        if (Quaternion.Angle(now_rot, target) < 45 && up)
        {
            target_rotateZ = -25f;
            up = false;
            speed = 0.5f;
            if (gameSetting.r_rotation)
            {
                gameSetting.LeftOarStop = false;
            }
        }
        if (Quaternion.Angle(now_rot, target) < 20 && !up)
        {
            if (gameSetting.advance && gameSetting.RightOarStop
                || gameSetting.r_rotation)
            {
                target_rotateZ = 65f;
                up = true;
                speed = 1.5f;
                if(gameSetting.r_rotation)
                {
                    gameSetting.LeftOarStop = false;
                }
            }
        }

        if (up)
        {
            transform.Rotate(new Vector3(0, -speed, speed));
        }
        if (!up)
        {
            transform.Rotate(new Vector3(0, speed, -speed));
        }

    }

    void RunRight()
    {
        Vector3 tran = this.gameObject.transform.localEulerAngles;
        var target = Quaternion.Euler(new Vector3(tran.x, tran.y, target_rotateZ));
        var now_rot = transform.rotation;

        // Angle → ２つの角度の間の数値
        if (Quaternion.Angle(now_rot, target) < 20 && !up)
        {
            if (!gameSetting.advance
                || !gameSetting.l_rotation)
            {
                speed = 0f;
                if (!gameSetting.l_rotation)
                {
                    gameSetting.RightOarStop = true;
                }
            }
        }
        if (Quaternion.Angle(now_rot, target) < 45 && up)
        {
            //transform.rotation = target; // 停止
            target_rotateZ = -25f;
            up = false;
            speed = 0.5f;
            if (gameSetting.l_rotation)
            {
                gameSetting.RightOarStop = false;
            }
        }
        if (Quaternion.Angle(now_rot, target) < 20 && !up)
        {
            if(gameSetting.advance && gameSetting.LeftOarStop
               || gameSetting.l_rotation)
            {
                target_rotateZ = 65f;
                up = true;
                speed = 1.5f;
                if (gameSetting.l_rotation)
                {
                    gameSetting.RightOarStop = false;
                }
            }
        }

        if (up)
        {
            transform.Rotate(new Vector3(0, speed, speed));
        }
        if (!up)
        {
            transform.Rotate(new Vector3(0, -speed, -speed));
        }

    }

}
