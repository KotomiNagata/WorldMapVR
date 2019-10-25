using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyPosition parent;
    GameSystem system;
    Collider col;
    float time = 8f;
    Vector3 startPos;
    int HP = 0;

    void Start()
    {
        parent = GetComponent<EnemyPosition>();
        system = GetComponent<GameSystem>();
        col = GetComponent<Collider>();
        startPos = this.transform.position;
        col.isTrigger = false;
        HP = 0;
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

        if (this.time < 0f ||
            parent.enemyDestory && )
        {
            Destroy(this.gameObject);
        }
    }

}
