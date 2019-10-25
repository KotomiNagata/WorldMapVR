using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum AnimType
    {
        USUALLY,
        QUIZ
    }
    public AnimType animType;
    EnemyPosition parentScript;
    GameSystem system;
    Collider col;

    float time = 8f;
    Vector3 startPos;
    public bool noDie = false;
    GameObject parentObj;

    void Start()
    {
        parentObj = this.transform.parent.gameObject;
        parentScript = parentObj.GetComponent<EnemyPosition>();

        if (animType == AnimType.USUALLY)
        {
            system = GetComponent<GameSystem>();
            col = GetComponent<Collider>();
            startPos = this.transform.position;
            col.isTrigger = false;
        }
    }

    void Update()
    {
        if (animType == AnimType.USUALLY)
        {
            UsuallyScript();
        }

        if(animType == AnimType.QUIZ)
        {
            QuizScript();
        }
    }

    void UsuallyScript()
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
            parentScript.enemyDestory)
        {
            Destroy(this.gameObject);
        }
    }

    void QuizScript()
    {
        if (parentScript.enemyDestory == false)
        {
            Destroy(this.gameObject);
        }
    }
}
