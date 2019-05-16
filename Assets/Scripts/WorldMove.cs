using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{

    public int walkSpeed;
    public int rotationSpeed;

    void Start()
    {
        
    }


    void Update()
    {
        // 上キー：前進
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(walkSpeed, 0, 0) * Time.deltaTime, Space.World);
        }
        // 下キー：後退
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(-walkSpeed, 0, 0) * Time.deltaTime, Space.World);
        }
        // 右キー：反時計回り
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, -rotationSpeed, 0) * Time.deltaTime, Space.World);
        }
        // 左キー：時計回り
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime, Space.World);
        }
    }
}
