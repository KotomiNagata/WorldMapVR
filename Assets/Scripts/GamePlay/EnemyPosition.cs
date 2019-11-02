using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    GameSystem system;
    PositionList posList;

    [Header("敵のオブジェクト")]
    public GameObject enemy;
    public GameObject enemyQuiz;

    [Header("クイズ問題のテキストオブジェクト")]
    public GameObject cityName_Quiz;
    public GameObject cityName_Good;
    public GameObject cityName_Miss;
    [System.NonSerialized]
    public bool enemyDestory = false;
    bool cloneEnemy = false;
    bool cloneEnemyQuiz = false;
    bool cloneEnemyAnswer = false;
    string myName;

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        posList = FindObjectOfType<PositionList>();
        myName = this.transform.name;
        enemyDestory = false;
    }

    void Update()
    {
        // エネミー生成
        EnemyCreat();

        // クイズ発生時
        if(system.selectEnemy)
        {
            StartQuiz();
        }

        // 答えを出す
        if(system.quizEnd && system.enemyName == myName && cloneEnemyAnswer)
        {
            AnswerQuiz();
        }

        if(!system.quizStart)
        {
            enemyDestory = false;
            cloneEnemyQuiz = true;
            cloneEnemyAnswer = true;
        }
    }

    // 花とぶつかった時に、EnemyPositionは消滅
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lotus" && system.noon)
        {
            posList.flowerName = myName;
            posList.flowerPlus = true;
            Destroy(this.gameObject);
        }
    }

    void EnemyCreat()
    {
        if (posList.posResult == myName && posList.cloneOK && !system.selectEnemy)
        {
            cloneEnemy = true;
        }
        if (cloneEnemy)
        {
            GameObject Obj;
            Obj = (GameObject)Instantiate(enemy, this.transform.position, this.transform.rotation);
            Obj.name = myName;
            Obj.transform.parent = transform;
            cloneEnemy = false;
        }
    }

    void StartQuiz()
    {
        enemyDestory = true;

        // クイズ問題を出題
        if (system.enemyName == myName && cloneEnemyQuiz)
        {
            GameObject obj2 = (GameObject)Instantiate(cityName_Quiz,
                                                          transform.position,
                                                          transform.rotation);
            obj2.transform.parent = transform;
            GameObject obj3 = (GameObject)Instantiate(enemyQuiz,
                                                      transform.position,
                                                      transform.rotation);
            obj3.transform.parent = transform;
            cloneEnemyQuiz = false;
        }
    }

    void AnswerQuiz()
    {
        // 答えを出す
        if (system.quizGood)
        {
            GameObject obj = Instantiate(cityName_Good,
                                         transform.position,
                                         transform.rotation);
            obj.transform.parent = transform;
            cloneEnemyAnswer = false;
        }
        if (system.quizMiss)
        {
            GameObject obj = Instantiate(cityName_Miss,
                                         transform.position,
                                         transform.rotation);
            obj.transform.parent = transform;
            cloneEnemyAnswer = false;
        }
    }
}
