using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusColor : MonoBehaviour
{
    GameSystem system;
    GameScore score;

    public Material[] materials;
    Renderer rend;
    int cnt = 0;
    bool change = false;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        system = FindObjectOfType<GameSystem>();
        score = FindObjectOfType<GameScore>();
        score.AddPoint(10);
        score.AddEnemyEnelgy(1);
        rend.material.color = materials[cnt].color;
    }

    void Update()
    {/*
        if (system.noon == true && change == false)
        {
            rend.material = materials[cnt = 0];
            change = true;
        }
        if (system.noon == false && change == true)
        {
            rend.material = materials[cnt = 1];
            change = false;
        }*/
    }
}
