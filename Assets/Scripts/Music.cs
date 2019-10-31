using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [Header("消えるまでの時間")]
    public float time;

    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
