using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus : MonoBehaviour
{
    GameObject Camera_obj;  // PlayCameraを探す
    public float dis;       // 花とカメラの距離間
    public GameObject Hologram;
    public GameObject Sekaiisan;
    bool one = true;       // Cloneを作る

    void Start()
    {
        Camera_obj = GameObject.FindGameObjectWithTag("PlayerCamera");
    }

    void Update()
    {
        // 位置情報取得
        Vector3 Camera_pos = Camera_obj.transform.position;
        Vector3 Holo_pos = this.transform.position;
        dis = Vector3.Distance(Camera_pos, Holo_pos);

        if(dis < 3f)
        {
            if(one)
            {
                Instantiate(Hologram);
                Instantiate(Sekaiisan);
                one = false;
            }
        }
        if(dis > 3f)
        {
            one = true;
        }
    }
}
