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
    public GameObject usuallyEnemy;

    void Start()
    {
        system =FindObjectOfType<GameSystem>();
        parentObj = this.transform.parent.gameObject;
        parentScript = parentObj.GetComponent<EnemyPosition>();

        if (animType == AnimType.USUALLY)
        {
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

        if(system.selectEnemy)
        {
            Destroy(this.gameObject);
        }
    }

    void QuizScript()
    {
        if (system.quizEnd)
        {
            GameObject obj = (GameObject)Instantiate(usuallyEnemy,
                                                     this.transform.position,
                                                     this.transform.rotation);
            obj.transform.parent = transform;
            Destroy(this.gameObject);
        }
    }
}
