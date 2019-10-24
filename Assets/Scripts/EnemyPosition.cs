using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    GameSystem system;
    PositionList posList;
    public GameObject enemy;
    public GameObject cityName;
    bool cloneEnemy = false;
    bool cloneText = false;
    Vector3 pos;
    string myName;

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        posList = FindObjectOfType<PositionList>();
        myName = this.transform.name;
    }

    void Update()
    {
        if(posList.posResult == myName && posList.cloneOK && system.noon)
        {
            cloneEnemy = true;
        }
        if(cloneEnemy)
        {
            GameObject obj1 = (GameObject)Instantiate(enemy, this.transform.position, this.transform.rotation);
            obj1.name = myName;
            obj1.transform.parent = transform;
            GameObject obj2 = (GameObject)Instantiate(cityName, transform.position, transform.rotation);
            obj2.transform.parent = transform;
            cloneEnemy = false;
        }
        if(cloneText)
        {
            GameObject obj2 = (GameObject)Instantiate(cityName, transform.position, transform.rotation);
            obj2.transform.parent = transform;
            cloneText = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lotus")
        {
            posList.flowerName = myName;
            posList.flowerPlus = true;
            Destroy(this.gameObject);
        }
    }
}
