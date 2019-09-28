using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusFlower : MonoBehaviour
{
    GameObject Camera_obj;  // PlayCameraを探す
    public float dis;       // 花とカメラの距離間
    public GameObject Hologram;
    public GameObject Sekaiisan;
    public GameObject HoloPos;
    public GameObject SekaPos;
    public bool one = true;       // Cloneを作る

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
                var parent = this.transform;
                Instantiate(Hologram, HoloPos.transform.position, Quaternion.identity, parent);
                Instantiate(Sekaiisan, SekaPos.transform.position, Quaternion.identity, parent);
                one = false;
            }
        }
        if(dis > 3f)
        {
            one = true;
        }
    }
}
