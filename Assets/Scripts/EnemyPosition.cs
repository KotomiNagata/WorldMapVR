using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    PositionList posList;
    public GameObject enemy;
    bool clone = false;
    Vector3 pos;
    Vector3 clonePos;
    string myName;

    void Start()
    {
        posList = FindObjectOfType<PositionList>();
        myName = this.transform.name;

        pos = this.transform.position;
        //pos.y += -0.005f;
        clonePos = pos;
    }

    void Update()
    {
        if(posList.posResult == myName && posList.cloneOK)
        {
            clone = true;
        }
        if(clone)
        {
            GameObject obj = (GameObject)Instantiate(enemy, clonePos, this.transform.rotation);
            obj.transform.parent = transform;
            clone = false;
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
