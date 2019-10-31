using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    float timer = 0.5f;   // タイマー時間

    void Update()
    {
        // タイマー
        this.timer -= Time.deltaTime;
        if (this.timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
