using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider col;
    float time = 8f;
    Vector3 startPos;

    void Start()
    {
        col = GetComponent<Collider>();
        startPos = this.transform.position;
        col.isTrigger = false;
    }

    void Update()
    {
        // タイマー
        this.time -= Time.deltaTime;

        // 0.5秒後にTriggerON
        if (this.time < 7.5f)
        {
            col.isTrigger = true;
        }
        // 7秒後にTriggerOFF
        if (this.time < 1f)
        {
            col.isTrigger = false;
        }

        if (this.time < 0f)
        {
            Destroy(this.gameObject);
        }
    }

}
