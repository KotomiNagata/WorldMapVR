using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    GameSystem system;
    PositionList posList;
    public GameObject enemy;
    public GameObject enemyQuiz;
    public GameObject cityName_Quiz;
    public GameObject cityName_Good;
    public GameObject cityName_Miss;
    public bool enemyDestory = false;
    bool cloneEnemy = false;
    bool cloneEnemyQuiz = false;
    Vector3 pos;
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
        else{
            enemyDestory = false;
            cloneEnemyQuiz = true;
        }
    }

    // 花とぶつかった時に、EnemyPositionは消滅
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lotus")
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
            GameObject obj1 = (GameObject)Instantiate(enemy, this.transform.position, this.transform.rotation);
            obj1.name = myName;
            obj1.transform.parent = transform;
            cloneEnemy = false;
        }
    }

    void StartQuiz()
    {
        enemyDestory = true;

        if (system.enemyName == myName)
        {
            if (cloneEnemyQuiz)
            {
                GameObject obj2 = (GameObject)Instantiate(cityName_Quiz, transform.position, transform.rotation);
                obj2.transform.parent = transform;
                GameObject obj3 = (GameObject)Instantiate(enemyQuiz, transform.position, transform.rotation);
                obj3.transform.parent = transform;
                cloneEnemyQuiz = false;
            }
        }
    }
}
