using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    GameSetting gameSetting;
    public int walkSpeed;
    public int rotationSpeed;

    void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
    }


    void Update()
    {
        // 前進
        if(gameSetting.advance
           && gameSetting.LeftOarStop
           && gameSetting.RightOarStop)
        {
            transform.Rotate(new Vector3(walkSpeed, 0, 0) * Time.deltaTime, Space.World);
        }
        // 右回転
        if (gameSetting.r_rotation)
        {
            transform.Rotate(new Vector3(0, -rotationSpeed, 0) * Time.deltaTime, Space.World);
        }
        // 左回転
        if (gameSetting.l_rotation)
        {
            transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime, Space.World);
        }
    }
}
